using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;

namespace TwoFishCrypto
{
    public static class CryptoHelper
    {
        public static void EncryptFile(string filePath, string encryptedFilePath, string keyHex, string ivHex)
        {
            byte[] plainText = File.ReadAllBytes(filePath);
            byte[] key = ConvertHexStringToByteArray(keyHex);
            byte[] iv = ConvertHexStringToByteArray(ivHex);
            byte[] encryptedBytes;
            Encrypt(plainText, out encryptedBytes, key, iv);
            File.WriteAllBytes(encryptedFilePath, encryptedBytes);
        }

        public static void Encrypt(byte[] plainText, out byte[] encryptedBytes, byte[] key, byte[] iv)
        {
            var engine = new TwofishEngine();
            var cipher = new CbcBlockCipher(engine);
            var parameters = new ParametersWithIV(new KeyParameter(key), iv);
            cipher.Init(true, parameters);

            int blockSize = cipher.GetBlockSize();
            int numChunks = (int)Math.Ceiling((double)plainText.Length / blockSize);

            var encryptedData = new List<byte>(plainText.Length);

            for (int i = 0; i < numChunks; i++)
            {
                byte[] inputBlock = new byte[blockSize];
                byte[] outputBlock = new byte[blockSize];

                int length = Math.Min(blockSize, plainText.Length - i * blockSize);
                Array.Copy(plainText, i * blockSize, inputBlock, 0, length);

                if (length < blockSize)
                {
                    for (int j = length; j < blockSize; j++)
                    {
                        inputBlock[j] = (byte)blockSize;
                    }
                }

                int processedBytes = cipher.ProcessBlock(inputBlock, 0, outputBlock, 0);
                encryptedData.AddRange(outputBlock);
            }

            encryptedBytes = encryptedData.ToArray();
        }

        public static void DecryptFile(string encryptedFilePath, string decryptedFilePath, string keyHex, string ivHex)
        {
            byte[] encryptedBytes = File.ReadAllBytes(encryptedFilePath);
            byte[] key = ConvertHexStringToByteArray(keyHex);
            byte[] iv = ConvertHexStringToByteArray(ivHex);
            byte[] decryptedBytes;
            Decrypt(encryptedBytes, out decryptedBytes, key, iv);
            
            if (decryptedBytes.Length > 0)
            {
                int lastByte = decryptedBytes[decryptedBytes.Length - 1];
                if (lastByte > 0 && lastByte <= 16)
                {
                    bool isPadding = true;
                    for (int i = decryptedBytes.Length - lastByte; i < decryptedBytes.Length; i++)
                    {
                        if (decryptedBytes[i] != lastByte)
                        {
                            isPadding = false;
                            break;
                        }
                    }
                    if (isPadding)
                    {
                        Array.Resize(ref decryptedBytes, decryptedBytes.Length - lastByte);
                    }
                }
            }
            
            string decryptedText = Encoding.UTF8.GetString(decryptedBytes);
            SaveDecryptedTextToFile(decryptedText, decryptedFilePath);
        }

        public static string DecryptFileToString(string encryptedFilePath, string keyHex, string ivHex)
        {
            byte[] encryptedBytes = File.ReadAllBytes(encryptedFilePath);
            byte[] key = ConvertHexStringToByteArray(keyHex);
            byte[] iv = ConvertHexStringToByteArray(ivHex);
            byte[] decryptedBytes;
            Decrypt(encryptedBytes, out decryptedBytes, key, iv);
            
            if (decryptedBytes.Length > 0)
            {
                int lastByte = decryptedBytes[decryptedBytes.Length - 1];
                if (lastByte > 0 && lastByte <= 16)
                {
                    bool isPadding = true;
                    for (int i = decryptedBytes.Length - lastByte; i < decryptedBytes.Length; i++)
                    {
                        if (decryptedBytes[i] != lastByte)
                        {
                            isPadding = false;
                            break;
                        }
                    }
                    if (isPadding)
                    {
                        Array.Resize(ref decryptedBytes, decryptedBytes.Length - lastByte);
                    }
                }
            }
            
            return Encoding.UTF8.GetString(decryptedBytes);
        }

        public static void Decrypt(byte[] cipherText, out byte[] plainText, byte[] key, byte[] iv)
        {
            var engine = new TwofishEngine();
            var cipher = new CbcBlockCipher(engine);
            var parameters = new ParametersWithIV(new KeyParameter(key), iv);
            cipher.Init(false, parameters);

            int blockSize = cipher.GetBlockSize();
            int numChunks = cipherText.Length / blockSize;

            var plainTextList = new List<byte>(cipherText.Length);

            for (int i = 0; i < numChunks; i++)
            {
                byte[] inputBlock = new byte[blockSize];
                byte[] outputBlock = new byte[blockSize];

                Array.Copy(cipherText, i * blockSize, inputBlock, 0, blockSize);
                int processedBytes = cipher.ProcessBlock(inputBlock, 0, outputBlock, 0);

                plainTextList.AddRange(outputBlock);
            }

            plainText = plainTextList.ToArray();
        }

        private static byte[] ConvertHexStringToByteArray(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException("Hex string must have an even number of characters");
            }
            
            byte[] bytes = new byte[hexString.Length / 2];
            for (int i = 0; i < hexString.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }
            return bytes;
        }

        private static void SaveDecryptedTextToFile(string decryptedText, string decryptedFilePath)
        {
            File.WriteAllText(decryptedFilePath, decryptedText);
        }
    }
}