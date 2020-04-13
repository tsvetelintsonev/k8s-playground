$namespace = kubectl get namespace --all-namespaces=true | Select-String -Pattern "nemstore-staging"

if (!($namespace -match "nemstore-staging")) {
    kubectl create -f ..\k8s\namespaces\nemstore-staging-namespace.yml
}

kubectl -n nemstore-staging delete deployment, service, mapping --all

# apps
kubectl apply -f ..\k8s\apps\staging\nemstore-frontend.yml
kubectl apply -f ..\k8s\apps\staging\nemstore-bff.yml
kubectl apply -f ..\k8s\apps\staging\nemstore-productscatalog.yml

# networking
kubectl apply -f ..\k8s\apps\staging\networking\ambassador\nemstore-frontend-mapping.yml
kubectl apply -f ..\k8s\apps\staging\networking\ambassador\nemstore-bff-mapping.yml