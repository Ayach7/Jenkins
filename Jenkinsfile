pipeline {
    agent any
    
    stages {
        stage('Clone Repository') {
            steps {
                git branch: 'main', url: 'https://github.com/Ayach7/Jenkins.git'
            }
        }
        
        stage('Restore Dependencies') {
            steps {
                bat 'dotnet restore'
            }
        }
        
        stage('Build Project') {
            steps {
                bat 'dotnet build --configuration Release'
            }
        }
        
        stage('Run Tests') {
            steps {
                bat 'dotnet test'
            }
        }
        
        stage('Publish') {
            steps {
                bat 'dotnet publish --configuration Release'
            }
        }
    }
}