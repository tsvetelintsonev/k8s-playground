$namespace = kubectl get namespace --all-namespaces=true | Select-String -Pattern "nemstore-dev"

if (!($namespace -match "nemstore-dev")) 
{
    kubectl create -f ..\k8s\nemstore-dev-namespace.yml
}

kubectl -n nemstore-dev delete deployment,service --all

# kubectl apply -f .\k8s\webapp.yml
# kubectl apply -f .\k8s\servicea.yml
# kubectl apply -f .\k8s\serviceb.yml
# kubectl apply -f .\k8s\servicec.yml
kubectl apply -f ..\k8s\apps\dev\nemstore-frontend.yml
kubectl apply -f ..\k8s\apps\dev\nemstore-bff.yml
kubectl apply -f ..\k8s\apps\dev\nemstore-productscatalog.yml