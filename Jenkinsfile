pipeline {
    agent any
    stages {
        stage('Git checkout'){
            steps{
            git branch: 'master', url: 'https://github.com/viktorilin/DEMO.git'
            }
        }
        stage('Restore Nuget'){
            steps{
            bat 'E:/SS/nuget.exe restore DEMO.sln'
            }
        }
        stage('build'){
            steps{
            bat "\"${tool 'MSBuildLocal'}\" DEMO.sln /p:Configuration=Debug /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
            }
        }
        stage('Execute All Tests'){
            steps{
                echo "${env.WORKSPACE}"
                
                bat "\"${env.WORKSPACE}\\packages\\NUnit.ConsoleRunner.3.10.0\\tools\\nunit3-console.exe\"  DEMO/bin/Debug/DEMO.dll"
                
            }
        }
    }
    post { 
        always { 
            bat '"API/bin/Debug/API.exe"'
        }
    }
}

