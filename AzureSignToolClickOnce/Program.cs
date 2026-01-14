using AzureSignToolClickOnce.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AzureSignToolClickOnce
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = ".";
            var description = string.Empty;
            string timeStampUrl = string.Empty;
            string timeStampUrlRfc3161 = string.Empty;
            var keyVaultUrl = string.Empty;
            var ADTenantId = string.Empty;
            var clientId = string.Empty;
            var clientSecret = string.Empty;
            var certName = string.Empty;
            var additionalFilesToSign = new List<string>();

            foreach (string arg in args)
            {
                if (!arg.StartsWith("-") || arg.Length < 4)
                    continue;

                var split = arg.IndexOf('=');
                if (split == -1)
                    continue;

                var key = arg.Substring(0, split).Trim();
                var value = arg.Substring(split + 1, arg.Length - split - 1).Trim();

                switch (key)
                {
                    case "-p":
                    case "-path":
                        path = value;
                        break;
                    case "-azure-key-vault-url":
                        keyVaultUrl = value;
                        break;
                    case "-azure-key-vault-client-id":
                        clientId = value;
                        break;
                    case "-azure-key-vault-client-secret":
                        clientSecret = value;
                        break;
                    case "-azure-key-vault-tenant-id":
                        ADTenantId = value;
                        break;
                    case "-azure-key-vault-certificate":
                        certName = value;
                        break;
                    case "-timestamp-sha2":
                        timeStampUrl = value;
                        break;
                    case "-timestamp-rfc3161":
                        timeStampUrlRfc3161 = value;
                        break;
                    case "-description":
                        description = value;
                        break;
                    case "-additional-files":
                        // Support comma-separated patterns
                        var patterns = value.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(p => p.Trim())
                                            .Where(p => !string.IsNullOrEmpty(p));
                        additionalFilesToSign.AddRange(patterns);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine($"Path: {path}");

            if (string.IsNullOrEmpty(keyVaultUrl))
            {
                Console.WriteLine($"Missing option -azure-key-vault-url");
                return;
            }
            if (string.IsNullOrEmpty(ADTenantId))
            {
                Console.WriteLine($"Missing option -azure-key-vault-tenant-id");
                return;
            }
            if (string.IsNullOrEmpty(certName))
            {
                Console.WriteLine($"Missing option -azure-key-vault-certificate");
                return;
            }
            if (string.IsNullOrEmpty(description))
            {
                Console.WriteLine($"Missing option -description");
                return;
            }
            if (string.IsNullOrEmpty(timeStampUrl))
            {
                Console.WriteLine($"Missing option -timestamp-sha2");
            }
            if (string.IsNullOrEmpty(timeStampUrlRfc3161))
            {
                Console.WriteLine($"Missing option -timestamp-rfc3161");
            }

            if (additionalFilesToSign.Any())
            {
                Console.WriteLine($"Additional files to sign: {string.Join(", ", additionalFilesToSign)}");
            }

            var service = new AzureSignToolService();
            service.Start(
                description,
                path,
                timeStampUrl,
                timeStampUrlRfc3161,
                keyVaultUrl,
                ADTenantId,
                clientId,
                clientSecret,
                certName,
                additionalFilesToSign.Any() ? additionalFilesToSign.ToArray() : null);
        }
    }
}
