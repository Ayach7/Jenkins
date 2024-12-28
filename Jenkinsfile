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
        stage('Docker Build') {
            steps {
                bat 'docker build -t ayach2000/repository:latest .'
            }
        }
        stage('Push Docker Image') {
            steps {
                bat 'docker login -u ayach2000 -p ayadocker'
                bat 'docker push ayach2000/repository:latest'
            }
        }
        stage('Deploy') {
            steps {
                sshagent(['deploy-key']) {
                    bat 'scp docker-compose.yml user@remote-server:/path/to/deploy'
                    bat 'ssh user@remote-server "docker-compose up -d"'
                }
            }
        }
    }
}
