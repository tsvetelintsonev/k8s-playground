docker build -f webapp/Dockerfile -t k8s-playground_webapp:k8s ./ --no-cache
docker build -f services/servicea/Dockerfile -t k8s-playground_servicea:k8s ./ --no-cache
docker build -f services/serviceb/Dockerfile -t k8s-playground_serviceb:k8s ./ --no-cache
docker build -f services/ servicec/Dockerfile -t k8s-playground_servicec:k8s ./ --no-cache