
# Azure ClickOnce Sign Tool

Command-line utility for signing ClickOnce manifests using a certificate stored in an Azure Key Vault.

Forked from [davici-code/AzureSignToolClickOnce](https://github.com/davici-code/AzureSignToolClickOnce).

## Updates

The following updates have been made from the original tool:

- Use the updated [dotnet-mage](https://github.com/dotnet/deployment-tools/blob/main/docs/dotnet-mage/README.md) tool
- Support federated authentication
  - Exclude the `azure-key-vault-client-id` and `azure-key-vault-client-secret` to use this

## Usage

```shell
AzureSignToolClickOnce.exe ^\
 -p=bin\Release\app.publish\^\
 -azure-key-vault-url=https://1234-vault.vault.azure.net/^\
 -azure-key-vault-client-id=1234^\
 -azure-key-vault-client-secret=1234^\
 -azure-key-vault-tenant-id=1234^\
 -azure-key-vault-certificate=MyGlobalSignCert^\
 -timestamp-sha2=http://timestamp.globalsign.com/?signature=sha2^\
 -timestamp-rfc3161=http://rfc3161timestamp.globalsign.com/advanced^\
 -description=MyApp^
```

## Download

Download the latest version [here](https://github.com/jessekingf/AzureSignToolClickOnce/releases).

### Prerequisites

The following prerequisites are required to run the utility:

1. [.NET Framework 4.8](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48)
2. [.NET 9.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
3. [dotnet-mage](https://github.com/dotnet/deployment-tools/blob/main/docs/dotnet-mage/README.md)
