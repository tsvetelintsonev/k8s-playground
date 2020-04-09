# docker build -f webapp/Dockerfile -t k8s-playground_webapp:k8s ./ --no-cache
# docker build -f web/frontend/angular/nemstore/Dockerfile -t nemstore-frontend:1.0.0 ./ --no-cache
docker build -f web/backend/Nemstore.Bff/Dockerfile -t nemstore-bff:1.0.0 ./ --no-cache
docker build -f services/Nemstore.ProductsCatalog.Api/Dockerfile -t nemstore-productscatalog:1.0.0 ./ --no-cache
# docker build -f services/serviceb/Dockerfile -t k8s-playground_serviceb:k8s ./ --no-cache
# docker build -f services/servicec/Dockerfile -t k8s-playground_servicec:k8s ./ --no-cache