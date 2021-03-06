$namespace = kubectl get namespace --all-namespaces=true | Select-String -Pattern "nemstore-prod"

if (!($namespace -match "nemstore-prod")) {
    kubectl create -f ..\k8s\namespaces\nemstore-prod-namespace.yml
}

kubectl -n nemstore-prod delete deployment, service, mapping --all

# apps
kubectl apply -f ..\k8s\apps\prod\nemstore-frontend.yml
kubectl apply -f ..\k8s\apps\prod\nemstore-bff.yml
kubectl apply -f ..\k8s\apps\prod\nemstore-productscatalog.yml

# networking
kubectl apply -f ..\k8s\apps\prod\networking\ambassador\nemstore-frontend-mapping.yml
kubectl apply -f ..\k8s\apps\prod\networking\ambassador\nemstore-bff-mapping.yml