# Aspire test

Small repository made to learn more about [Aspire](https://aspire.dev/), and to test out
dotnet development on linux.
All development is done in [JetBrains Rider](https://www.jetbrains.com/rider/), so the project
might look or function differently in other IDEs.

## About the project

This is the backend for a (when possible[^1]) peer-to-peer encrypted chat app. Please create
[an issue](https://github.com/kwmbe/aspire-test/issues/new) if there are any issues or
security concerns.

## Running the project

1. Make sure Docker and dotnet are installed, and the Docker daemon is running, since aspire uses
docker to host different parts of the application.
2. That's all. Press `F5` to run the project, this should open a webpage.

[^1]: For asynchronous messaging, encrypted messages will be queued server-side and
delivered when the receiving party goes online.
