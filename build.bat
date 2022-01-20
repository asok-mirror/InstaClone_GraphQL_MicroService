start /d "." dotnet run --project Post/Post/Post.csproj -c Release --urls "http://localhost:5001;
start /d "." dotnet run --project User/User/User.csproj -c Release --urls "http://localhost:5005;
start /d "." dotnet run --project Gateway/Gateway/Gateway.csproj -c Release --urls "http://localhost:5000;
start /d "." Comments\venv\Scripts\activate.bat && python Comments\main.py 
@REM start /d "." dotnet run 
@REM start /d "." dotnet run 
@REM start /d "." dotnet run 