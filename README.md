# Tendo Toy Project
This is a simple project for handling a review of a patient visit. It can be run with

dotnet run --project ConsoleApp\ConsoleApp.csproj

Next steps
1. Add a file reader to initialize data from JSON
2. Update the data repository to use a database
3. Create a web based UI
4. Begin the dployment to AWS
	1. Create S3 bucket for files
	2. Refactor file processor into a lambda function
	3. Configure trigger to process file when loaded to S3 bucket
	4. Deploy web UI with services for accessessing database
	5. Create an email that notifies patient that there is a review to perform
	6. Replace mock sentiment analysis with Amazon Comprehend