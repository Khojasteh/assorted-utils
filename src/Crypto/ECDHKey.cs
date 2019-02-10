#if NET471
using System;
using System.Security.Cryptography;

namespace Assorted.Utils.Crypto
{
    /// <summary>
    /// Wraps the .NET Elliptic Curve Diffie-Hellmann key exchange algorithm (.NET Framework only).
    /// </summary>
    /// <remarks>
    /// The <see cref="ECDHKey"/> class is not available for .NET Standard and .NET Core framework targets.
    /// </remarks>
    /// <threadsafety static="true" instance="true"/>
    public class ECDHKey : IDisposable
    {
        /// <overloads>
        /// Initializes a new instance of <see cref="ECDHKey"/> class. 
        /// </overloads>
        /// <summary>
        /// Initializes a new instance of <see cref="ECDHKey"/> class, using Elliptic Curve Diffie-Hellmann P-256. 
        /// </summary>
        /// <param name="keyName">The name of the key, if the key should be persisted.</param>
        public ECDHKey(string keyName = null)
            : this(CngAlgorithm.ECDiffieHellmanP256, keyName) { }

        /// <summary>
        /// Initializes a new instance of <see cref="ECDHKey"/> class, using the specified curve algorithm. 
        /// </summary>
        /// <param name="algorithm">The algorithm the key will be used with.</param>
        /// <param name="keyName">The name of the key, if the key should be persisted.</param>
        /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="algorithm"/> is not a valid curve algorithm.</exception>
        /// <exception cref="InvalidOperationException">
        /// The key specified by <paramref name="keyName"/> is not using the specified <paramref name="algorithm"/>.
        /// </exception>
        public ECDHKey(CngAlgorithm algorithm, string keyName = null)
        {
            Contract.Requires<ArgumentNullException>(algorithm != null, nameof(algorithm));
            Contract.Requires<ArgumentException>(algorithm.Algorithm.StartsWith("ECDH_"), nameof(algorithm));

            key = LoadOrCreateKey(keyName, algorithm);
        }

        /// <summary>
        /// Finalizes the instance of <see cref="ECDHKey"/> class.
        /// </summary>
        ~ECDHKey()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets the name of the key if the key is persistent.
        /// </summary>
        /// <value>
        /// If the key is persistent, the value of this property is the key's name; otherwise, it is <see langword="null"/>.
        /// </value>
        public string KeyName => key.KeyName;

        /// <summary>
        /// Gets whether the key is an ephemeral key.
        /// </summary>
        public bool IsEphemeral => key.IsEphemeral;

        /// <summary>
        /// Gets the name of the algorithm, which the key is used with.
        /// </summary>
        public string Algorithm => key.Algorithm.Algorithm;

        /// <summary>
        /// Gets the public key of the key pair.
        /// </summary>
        public byte[] PublicKey => key.Export(CngKeyBlobFormat.EccPublicBlob);

        /// <summary>
        /// Derives the shared key from this party's private key and other party's public key.
        /// </summary>
        /// <param name="otherPublicKey">The public key of the other party.</param>
        /// <returns>The shared key as an array of bytes.</returns>
        public virtual byte[] DeriveSharedKey(byte[] otherPublicKey)
        {
            using (var ecdh = new ECDiffieHellmanCng(key))
            using (var otherKey = CngKey.Import(otherPublicKey, CngKeyBlobFormat.EccPublicBlob))
                return ecdh.DeriveKeyMaterial(otherKey);
        }

        /// <summary>
        /// Releases all resources used by the current instance of <see cref="ECDHKey"/> class.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="ECDHKey"/>, and optionally disposes 
        /// of the managed resources.
        /// </summary>
        /// <param name="disposing">
        /// <see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to 
        /// releases only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                key?.Dispose();
        }

        /// <summary>
        /// Loads or creates a cryptography key for the specified algorithm. 
        /// </summary>
        /// <param name="keyName">The name of the key, if the key should be persisted.</param>
        /// <param name="algorithm">The algorithm the key will be used with.</param>
        /// <returns>A <see cref="CngKey"/> object that contains data of the asymmetric key pair.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">
        /// The key specified by <paramref name="keyName"/> is not using the specified <paramref name="algorithm"/>.
        /// </exception>
        protected static CngKey LoadOrCreateKey(string keyName, CngAlgorithm algorithm)
        {
            Contract.Requires<ArgumentNullException>(algorithm != null, nameof(algorithm));

            if (keyName != null && CngKey.Exists(keyName, CngProvider.MicrosoftSoftwareKeyStorageProvider))
            { 
                var key = CngKey.Open(keyName, CngProvider.MicrosoftSoftwareKeyStorageProvider);
                if (algorithm.Equals(key.Algorithm))
                    return key;

                var keyAlgorithm = key.Algorithm;
                key.Dispose();
                throw new InvalidOperationException($"Key '{keyName}' is using {keyAlgorithm} algorithm but expected to use {algorithm} algorithm");
            }

            return CngKey.Create(algorithm, keyName);
        }

        private readonly CngKey key;
    }

}
#endif
