$namespace = kubectl get namespace --all-namespaces=true | Select-String -Pattern "nemstore-dev"

if (!($namespace -match "nemstore-dev")) 
{
    kubectl create -f ..\k8s\namespaces\nemstore-dev-namespace.yml
}

kubectl -n nemstore-dev delete deployment,service,mapping --all

# apps
kubectl apply -f ..\k8s\apps\dev\nemstore-frontend.yml
kubectl apply -f ..\k8s\apps\dev\nemstore-bff.yml
kubectl apply -f ..\k8s\apps\dev\nemstore-productscatalog.yml

# networking

# ambassador
kubectl apply -f ..\k8s\apps\dev\networking\ambassador\nemstore-frontend-mapping.yml
kubectl apply -f ..\k8s\apps\dev\networking\ambassador\nemstore-bff-mapping.yml

# istio
# kubectl apply -f ..\k8s\apps\dev\networking\istio\nemstore-frontend-virtual-service.yml
# kubectl apply -f ..\k8s\apps\dev\networking\istio\nemstore-bff-virtual-service.yml