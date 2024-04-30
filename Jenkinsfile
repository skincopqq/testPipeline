def SONAR_PROJECT_KEY = "testPipeline"
def SONAR_NAME = "sonar"
def SONAR_REPORT_FILE_NAME = "sonar-report.json"
def SLN_PATH = "src/Webstar.sln"

pipeline {
    agent  any

    stages {
		stage('Build') {
			steps{
				withSonarQubeEnv(SONAR_NAME){
					sh """
						dotnet tool install --global dotnet-sonarscanner
						dotnet sonarscanner begin /k:\"${SONAR_PROJECT_KEY}\"
						
						dotnet restore ${SLN_PATH} /nodeReuse:false
						dotnet build ${SLN_PATH} /nodeReuse:false
					"""
				}
			}
			
		}
        
    }
}