# azure-app-config-repo

Repo:

1. Clone this repo
2. Add `local.settings.json` to project root
3. Add a valid Azure App Configuration URL to `local.settings.json` with key `azureConfigUri`
4. Add key `sentinel` with any value to your Azure App Configuration
5. Add random key/values with prefix "common/"

If you add other than key/values to the configuration store and update them while the app is running, you'll see in Fiddler that
the application pulls them regardless of prefix, inclusion, select, etc. Also, regardless of refresh timeout, it'll pull the updates
immediately.
