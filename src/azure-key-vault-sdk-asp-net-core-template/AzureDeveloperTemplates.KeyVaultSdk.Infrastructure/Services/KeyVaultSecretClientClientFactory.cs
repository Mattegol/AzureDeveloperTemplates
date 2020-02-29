﻿using Azure.Security.KeyVault.Secrets;
using AzureDeveloperTemplates.KeyVaultSdk.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureDeveloperTemplates.KeyVaultSdk.Infrastructure.Services
{
    public class KeyVaultSecretClientClientFactory : IKeyVaultSecretClientClientFactory
    {
        public KeyVaultSecretClientClientFactory(SecretClient secretClient)
        {
            SecretClient = secretClient;
        }

        public SecretClient SecretClient { get; }
    }
}