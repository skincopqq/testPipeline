node {
    stage('SCM') {
    checkout scm
    }
    stage('SonarQube Analysis') {
    def scannerHome = tool 'SonarScanner for MSBuild'
    withSonarQubeEnv() {
        sh "/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/.NET_8/dotnet ${scannerHome}/SonarScanner.MSBuild.dll begin /k:\"testPipeline\""
        sh "/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/.NET_8/dotnet build"
        sh "/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/.NET_8/dotnet ${scannerHome}/SonarScanner.MSBuild.dll end"
    }
  }
}