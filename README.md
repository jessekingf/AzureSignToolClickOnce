
# Azure ClickOnce Sign Tool

Command-line utility for signing ClickOnce manifests using a certificate stored in an Azure Key Vault.

Forked from [davici-code/AzureSignToolClickOnce](https://github.com/davici-code/AzureSignToolClickOnce).

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
