# Sensitech Plugin Architecture

## Getting Started
- Install asp.net 5 following directions here: https://github.com/aspnet/home -- @powershell -NoProfile -ExecutionPolicy unrestricted -Command "&{$Branch='dev';iex ((new-object net.webclient).DownloadString('https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.ps1'))}"
- Run "dnvm upgrade"
- Run "dnu restore"
- go to wwwroot directory and run "npm install"
- Make sure you have SQL Server installed locally (the connection string should work if so)
- Run "dnx . ef migration apply" to run Entity Framework migrations and bootstrap the database

## Running the App
- Start the web server with "dnx . web"
- Run "gulp watch" to build and watch javascript build

## Info about the app
- webpack for javascript modules and gulp for javascript task runner
- typescript
- aspnet5 w/ Entity Framework 7 for server side
- each module has its own folder beneath src/js
- each module is built on its own as part of webpack.config.js but could be moved to independent build
