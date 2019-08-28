// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Assorted.Utils.Crypto
{
    /// <summary>
    /// Extends objects of type <see cref="X509Certificate2"/>.
    /// </summary>
    public static class CertExtenstions
    {
        /// <summary>
        /// Encrypts the specified byte array using the public key of the certificate and a specified padding mode.
        /// </summary>
        /// <param name="cert">A certificate object with public key.</param>
        /// <param name="data">The data to be ciphered as an array of bytes.</param>
        /// <param name="padding">The padding mode of the encryption.</param>
        /// <returns>The ciphered data as an array of bytes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="cert"/>, <paramref name="data"/>, or <paramref name="padding"/> is <see langword="null"/>.</exception>
        public static byte[] Encrypt(this X509Certificate2 cert, byte[] data, RSAEncryptionPadding padding)
        {
            Contract.Requires<ArgumentNullException>(cert != null, nameof(cert));
            Contract.Requires<ArgumentNullException>(data != null, nameof(data));
            Contract.Requires<ArgumentNullException>(padding != null, nameof(padding));

            using (var rsa = cert.GetRSAPublicKey())
                return rsa.Encrypt(data, padding);
        }

        /// <summary>
        /// Encrypts the specified byte array using the public key of the certificate and <see cref="RSAEncryptionPadding.OaepSHA1"/> padding mode.
        /// </summary>
        /// <param name="cert">A certificate object with public key.</param>
        /// <param name="data">The data to be ciphered as an array of bytes.</param>
        /// <returns>The ciphered data as an array of bytes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="cert"/> or <paramref name="data"/> is <see langword="null"/>.</exception>
        public static byte[] Encrypt(this X509Certificate2 cert, byte[] data)
        {
            return cert.Encrypt(data, RSAEncryptionPadding.OaepSHA1);
        }

        /// <summary>
        /// Decrypts the ciphered data using the private key of the certificate and a specified padding mode.
        /// </summary>
        /// <param name="cert">A certificate object with private key.</param>
        /// <param name="cipher">The ciphered data as an array of bytes.</param>
        /// <param name="padding">The padding mode of the decryption.</param>
        /// <returns>The plain data as an array of bytes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="cert"/>, <paramref name="cipher"/>, or <paramref name="padding"/> is <see langword="null"/>.</exception>
        public static byte[] Decrypt(this X509Certificate2 cert, byte[] cipher, RSAEncryptionPadding padding)
        {
            Contract.Requires<ArgumentNullException>(cert != null, nameof(cert));
            Contract.Requires<ArgumentNullException>(cipher != null, nameof(cipher));
            Contract.Requires<ArgumentNullException>(padding != null, nameof(padding));

            using (var rsa = cert.GetRSAPrivateKey())
                return rsa.Decrypt(cipher, padding);
        }

        /// <summary>
        /// Decrypts the ciphered data using the private key of the certificate and <see cref="RSAEncryptionPadding.OaepSHA1"/> padding mode.
        /// </summary>
        /// <param name="cert">A certificate object with private key.</param>
        /// <param name="cipher">The ciphered data as an array of bytes.</param>
        /// <returns>The plain data as an array of bytes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="cert"/> or <paramref name="cipher"/> is <see langword="null"/>.</exception>
        public static byte[] Decrypt(this X509Certificate2 cert, byte[] cipher)
        {
            return cert.Decrypt(cipher, RSAEncryptionPadding.OaepSHA1);
        }

        /// <summary>
        /// Computes the hash value of the specified byte array using the specified hash algorithm and padding mode, and signs the resulting hash value.
        /// </summary>
        /// <param name="cert">A certificate object with private key.</param>
        /// <param name="data">The input data for which to compute the hash.</param>
        /// <param name="hashAlgorithm">The hash algorithm to use to create the hash value.</param>
        /// <param name="padding">The padding mode.</param>
        /// <returns>The RSA signature for the specified data.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="cert"/>, <paramref name="data"/>, or <paramref name="padding"/> is <see langword="null"/>.</exception>
        public static byte[] Sign(this X509Certificate2 cert, byte[] data, HashAlgorithmName hashAlgorithm, RSASignaturePadding padding)
        {
            Contract.Requires<ArgumentNullException>(cert != null, nameof(cert));
            Contract.Requires<ArgumentNullException>(data != null, nameof(data));
            Contract.Requires<ArgumentNullException>(padding != null, nameof(padding));

            using (var rsa = cert.GetRSAPrivateKey())
                return rsa.SignData(data, hashAlgorithm, padding);
        }

        /// <summary>
        /// Computes the hash value of the specified byte array using SHA-256 algorithm and PSS padding mode, and signs the resulting hash value.
        /// </summary>
        /// <param name="cert">A certificate object with private key.</param>
        /// <param name="data">The input data for which to compute the hash.</param>
        /// <returns>The RSA signature for the specified data.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="cert"/> or <paramref name="data"/> is <see langword="null"/>.</exception>
        public static byte[] Sign(this X509Certificate2 cert, byte[] data)
        {
            return cert.Sign(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);
        }

        /// <summary>
        /// Computes the hash value of the specified stream using the specified hash algorithm and padding mode, and signs the resulting hash value.
        /// </summary>
        /// <param name="cert">A certificate object with private key.</param>
        /// <param name="stream">The input stream for which to compute the hash.</param>
        /// <param name="hashAlgorithm">The hash algorithm to use to create the hash value.</param>
        /// <param name="padding">The padding mode.</param>
        /// <returns>The RSA signature for the specified data.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="cert"/>, <paramref name="stream"/>, or <paramref name="padding"/> is <see langword="null"/>.</exception>
        public static byte[] Sign(this X509Certificate2 cert, Stream stream, HashAlgorithmName hashAlgorithm, RSASignaturePadding padding)
        {
            Contract.Requires<ArgumentNullException>(cert != null, nameof(cert));
            Contract.Requires<ArgumentNullException>(stream != null, nameof(stream));
            Contract.Requires<ArgumentNullException>(padding != null, nameof(padding));

            using (var rsa = cert.GetRSAPrivateKey())
                return rsa.SignData(stream, hashAlgorithm, padding);
        }

        /// <summary>
        /// Computes the hash value of the specified stream using SHA-256 hash algorithm and PSS padding mode, and signs the resulting hash value.
        /// </summary>
        /// <param name="cert">A certificate object with private key.</param>
        /// <param name="stream">The input stream for which to compute the hash.</param>
        /// <returns>The RSA signature for the specified data.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="cert"/> or <paramref name="stream"/> is <see langword="null"/>.</exception>
        public static byte[] Sign(this X509Certificate2 cert, Stream stream)
        {
            return cert.Sign(stream, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);
        }

        /// <summary>
        /// Computes the hash value of the specified string using the specified hash algorithm and padding mode, and signs the resulting hash value.
        /// </summary>
        /// <param name="cert">A certificate object with private key.</param>
        /// <param name="text">The input string for which to compute the hash.</param>
        /// <param name="hashAlgorithm">The hash algorithm to use to create the hash value.</param>
        /// <param name="padding">The padding mode.</param>
        /// <returns>The RSA signature for the specified data.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="cert"/>, <paramref name="text"/>, or <paramref name="padding"/> is <see langword="null"/>.</exception>
        public static byte[] Sign(this X509Certificate2 cert, string text, HashAlgorithmName hashAlgorithm, RSASignaturePadding padding)
        {
            Contract.Requires<ArgumentNullException>(cert != null, nameof(cert));
            Contract.Requires<ArgumentNullException>(text != null, nameof(text));
            Contract.Requires<ArgumentNullException>(padding != null, nameof(padding));

            using (var rsa = cert.GetRSAPrivateKey())
                return rsa.SignData(Encoding.UTF8.GetBytes(text), hashAlgorithm, padding);
        }

        /// <summary>
        /// Computes the hash value of the specified string using SHA-256 hash algorithm and PSS padding mode, and signs the resulting hash value.
        /// </summary>
        /// <param name="cert">A certificate object with private key.</param>
        /// <param name="text">The input string for which to compute the hash.</param>
        /// <returns>The RSA signature for the specified data.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="cert"/> or <paramref name="text"/> is <see langword="null"/>.</exception>
        public static byte[] Sign(this X509Certificate2 cert, string text)
        {
            return cert.Sign(text, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);
        }

        /// <summary>
        /// Verifies that a digital signature is valid by calculating the hash value of the specified data using the specified hash algorithm 
        /// and padding mode, and comparing it to the provided signature.
        /// </summary>
        /// <param name="cert">A certificate object with public key.</param>
        /// <param name="data">The signed data.</param>
        /// <param name="signature">The signature data to be verified.</param>
        /// <param name="hashAlgorithm">The hash algorithm used to create the hash value of the data.</param>
        /// <param name="padding">The padding mode.</param>
        /// <returns><see langword="true"/> if the signature is valid; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="cert"/>, <paramref name="data"/>, <paramref name="signature"/>, or <paramref name="padding"/> is <see langword="null"/>.</exception>
        public static bool VerifySignature(this X509Certificate2 cert, byte[] data, byte[] signature, HashAlgorithmName hashAlgorithm, RSASignaturePadding padding)
        {
            Contract.Requires<ArgumentNullException>(cert != null, nameof(cert));
            Contract.Requires<ArgumentNullException>(data != null, nameof(data));
            Contract.Requires<ArgumentNullException>(signature != null, nameof(signature));
            Contract.Requires<ArgumentNullException>(padding != null, nameof(padding));

            using (var rsa = cert.GetRSAPublicKey())
                return rsa.VerifyData(data, signature, hashAlgorithm, padding);
        }

        /// <summary>
        /// Verifies that a digital signature is valid by calculating the hash value of the specified data using SHA-256 hash algorithm 
        /// and PSS padding mode, and comparing it to the provided signature.
        /// </summary>
        /// <param name="cert">A certificate object with public key.</param>
        /// <param name="data">The signed data.</param>
        /// <param name="signature">The signature data to be verified.</param>
        /// <returns><see langword="true"/> if the signature is valid; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="cert"/>, <paramref name="data"/>, or <paramref name="signature"/> is <see langword="null"/>.</exception>
        public static bool VerifySignature(this X509Certificate2 cert, byte[] data, byte[] signature)
        {
            return cert.VerifySignature(data, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);
        }

        /// <summary>
        /// Verifies that a digital signature is valid by calculating the hash value of the specified stream using the specified hash algorithm 
        /// and padding mode, and comparing it to the provided signature.
        /// </summary>
        /// <param name="cert">A certificate object with public key.</param>
        /// <param name="stream">The signed data.</param>
        /// <param name="signature">The signature data to be verified.</param>
        /// <param name="hashAlgorithm">The hash algorithm used to create the hash value of the stream.</param>
        /// <param name="padding">The padding mode.</param>
        /// <returns><see langword="true"/> if the signature is valid; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="cert"/>, <paramref name="stream"/>, <paramref name="signature"/>, or <paramref name="padding"/> is <see langword="null"/>.</exception>
        public static bool VerifySignature(this X509Certificate2 cert, Stream stream, byte[] signature, HashAlgorithmName hashAlgorithm, RSASignaturePadding padding)
        {
            Contract.Requires<ArgumentNullException>(cert != null, nameof(cert));
            Contract.Requires<ArgumentNullException>(stream != null, nameof(stream));
            Contract.Requires<ArgumentNullException>(signature != null, nameof(signature));
            Contract.Requires<ArgumentNullException>(padding != null, nameof(padding));

            using (var rsa = cert.GetRSAPublicKey())
                return rsa.VerifyData(stream, signature, hashAlgorithm, padding);
        }

        /// <summary>
        /// Verifies that a digital signature is valid by calculating the hash value of the specified stream using SHA-256 hash algorithm 
        /// and PSS padding mode, and comparing it to the provided signature.
        /// </summary>
        /// <param name="cert">A certificate object with public key.</param>
        /// <param name="stream">The signed data.</param>
        /// <param name="signature">The signature data to be verified.</param>
        /// <returns><see langword="true"/> if the signature is valid; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="cert"/>, <paramref name="stream"/>, or <paramref name="signature"/> is <see langword="null"/>.</exception>
        public static bool VerifySignature(this X509Certificate2 cert, Stream stream, byte[] signature)
        {
            return cert.VerifySignature(stream, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);
        }

        /// <summary>
        /// Verifies that a digital signature is valid by calculating the hash value of the specified string using the specified hash algorithm 
        /// and padding mode, and comparing it to the provided signature.
        /// </summary>
        /// <param name="cert">A certificate object with public key.</param>
        /// <param name="text">The signed string.</param>
        /// <param name="signature">The signature data to be verified.</param>
        /// <param name="hashAlgorithm">The hash algorithm used to create the hash value of the string.</param>
        /// <param name="padding">The padding mode.</param>
        /// <returns><see langword="true"/> if the signature is valid; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="cert"/>, <paramref name="text"/>, <paramref name="signature"/>, or <paramref name="padding"/> is <see langword="null"/>.</exception>
        public static bool VerifySignature(this X509Certificate2 cert, string text, byte[] signature, HashAlgorithmName hashAlgorithm, RSASignaturePadding padding)
        {
            Contract.Requires<ArgumentNullException>(cert != null, nameof(cert));
            Contract.Requires<ArgumentNullException>(text != null, nameof(text));
            Contract.Requires<ArgumentNullException>(signature != null, nameof(signature));
            Contract.Requires<ArgumentNullException>(padding != null, nameof(padding));

            using (var rsa = cert.GetRSAPublicKey())
                return rsa.VerifyData(Encoding.UTF8.GetBytes(text), signature, hashAlgorithm, padding);
        }

        /// <summary>
        /// Verifies that a digital signature is valid by calculating the hash value of the specified string using SHA-256 hash algorithm 
        /// and PSS padding mode, and comparing it to the provided signature.
        /// </summary>
        /// <param name="cert">A certificate object with public key.</param>
        /// <param name="text">The signed string.</param>
        /// <param name="signature">The signature data to be verified.</param>
        /// <returns><see langword="true"/> if the signature is valid; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="cert"/>, <paramref name="text"/>, or <paramref name="signature"/> is <see langword="null"/>.</exception>
        public static bool VerifySignature(this X509Certificate2 cert, string text, byte[] signature)
        {
            return cert.VerifySignature(text, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);
        }
    }
}
