# Frontend apps
#docker build -f web/frontend/angular/nemstore/Dockerfile -t nemstore-frontend:1.0.0 . --no-cache
#docker build -f web/frontend/angular/nemstore-orders/Dockerfile -t nemstore-orders-frontend:1.0.0 . --no-cache

# Backend for frontend apps
docker build -f web/backend/Nemstore.Bff/Dockerfile -t nemstore-bff:1.0.0 . --no-cache
docker build -f web/backend/Nemstore.Orders.Bff/Dockerfile -t nemstore-orders-bff:1.0.0 . --no-cache

# Api apps
docker build -f services/Nemstore.ProductsCatalog.Api/Dockerfile -t nemstore-productscatalog:1.0.0 . --no-cache
docker build -f services/Nemstore.Orders.Api/Dockerfile -t nemstore-orders:1.0.0 . --no-cache