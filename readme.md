# Bitwarden Secret Manager Example Solution

This project represents a simple example of how to use the Bitwarden Secret Manager to store and manage secrets within an application. This solution was created by Okuhle Ngada.

## Description

This solution shows how Bitwarden Secret Manager can be used to store and manage secrets. To illustrate this, the solution has the following projects:

* SettingsLoader: This project is responsible for loading settings into the Bitwarden Secret Manager. This is done by reading a CSV file and loading the settings into the Secret Manager. In a real world scenario, the process may differ.
* SampleWebApi: This project is a sample web api project that uses the Bitwarden Secret Manager to retrieve and use secrets. In a real-world scenario, this could be classic a classic backend or a more sophisticated Web API. For simplicity, API security practises were excluded.
* Tests: This project contains a unit test for integration of the Secret Manager. This is an idea of how one could write tests against the integration.
* ApplicationUtilities: This project contains the domain models and services that are responsible for the Secret Manager.

## Getting Started

Ensure that you have the following installed:

* .NET 8.0 SDK. This can be installed from the Visual Studio Installer, or downloaded from the .NET website.
* Any IDE of your choice that supports .NET 8.0 projects. I use JetBrains Rider, but you can use anything (most typically use the Community version of Visual Studio).

Please ensure you have an existing Bitwarden account to make use of the secret management functionality. You may read more about this offering here. 

### Dependencies

* This sample can be run on any Machine with MacOS, Windows or Linux. Ran this on MacOS Sequoia.

### Executing program

* Run the SettingsLoader console application. Ensure that the settings.csv file is present, and has all the values you wish to load into the secret manager service.
* After runing the SettingsLoader, you can run the SampleWebApi application to verify the secrets are loaded

```
code blocks for commands
```

## Help

Any advise for common problems or issues.
```
command to run if program contains helper info
```

## Authors

Contributors names and contact info

Okuhle Ngada
[@okuhle.ngada (on threads.net)](https://www.threads.net/@okuhle.ngada?invite=0)
ex. [@DomPizzie](https://twitter.com/dompizzie)

## Version History

* 0.2
    * Various bug fixes and optimizations
    * See [commit change]() or See [release history]()
* 0.1
    * Initial Release

## License

This project is licensed under the [NAME HERE] License - see the LICENSE.md file for details

## Acknowledgments

I would like to thank Bitwarden for creating such an awesome SDK. 
* [awesome-readme](https://github.com/matiassingers/awesome-readme)
* [PurpleBooth](https://gist.github.com/PurpleBooth/109311bb0361f32d87a2)
* [dbader](https://github.com/dbader/readme-template)
* [zenorocha](https://gist.github.com/zenorocha/4526327)
* [fvcproductions](https://gist.github.com/fvcproductions/1bfc2d4aecb01a834b46)