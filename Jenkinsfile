def datas
pipeline {
    agent any
    stages {
        stage('Initialize the variables') {
            steps{
                script{
                    datas = readYaml file: 'demo.yaml'
                }
            }  
        }
        stage('Restore Nuget'){
            steps{
            bat "${datas.nugetStore} restore ${datas.solution}"
            }
        }
        stage('build'){
            steps{
            bat "\"${tool 'MSBuildLocal'}\" ${datas.solution} /p:Configuration=Debug /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
            }
        }
        stage('Execute All Tests'){
            steps{
                echo "${env.WORKSPACE}"
                bat "\"${env.WORKSPACE}${datas.nunitPath}\"  ${datas.testDllPath}"
                
            }
        }
    }
    post { 
        always { 
            echo "\"${env.WORKSPACE}${datas.postActionPath}\""
            bat "\"${env.WORKSPACE}${datas.postActionPath}\""
        }
    }
}