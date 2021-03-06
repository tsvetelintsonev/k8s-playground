$namespace = kubectl get namespace --all-namespaces=true | Select-String -Pattern "nemstore-dev"

if (!($namespace -match "nemstore-dev")) 
{
    kubectl create -f ..\k8s\namespaces\nemstore-dev-namespace.yml
}

kubectl -n nemstore-dev delete deployment,service,mapping --all

# Frontend apps
kubectl apply -f ..\k8s\apps\dev\nemstore-frontend.yml
kubectl apply -f ..\k8s\apps\dev\nemstore-orders-frontend.yml

# Backend for frontend apps
kubectl apply -f ..\k8s\apps\dev\nemstore-bff.yml
kubectl apply -f ..\k8s\apps\dev\nemstore-orders-bff.yml

# Api apps
kubectl apply -f ..\k8s\apps\dev\nemstore-productscatalog-api.yml
kubectl apply -f ..\k8s\apps\dev\nemstore-orders-api.yml

# networking
kubectl apply -f ..\k8s\apps\dev\networking\ambassador\nemstore-frontend-mapping.yml
kubectl apply -f ..\k8s\apps\dev\networking\ambassador\nemstore-bff-mapping.yml
kubectl apply -f ..\k8s\apps\dev\networking\ambassador\nemstore-orders-frontend-mapping.yml
kubectl apply -f ..\k8s\apps\dev\networking\ambassador\nemstore-orders-bff-mapping.yml