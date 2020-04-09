$namespace = kubectl get namespace --all-namespaces=true | Select-String -Pattern "nemstore-staging"

if (!($namespace -match "nemstore-staging")) 
{
    kubectl create -f ..\k8s\nemstore-staging-namespace.yml
}

kubectl -n nemstore-staging delete deployment,service --all

# kubectl apply -f .\k8s\webapp.yml
# kubectl apply -f .\k8s\servicea.yml
# kubectl apply -f .\k8s\serviceb.yml
# kubectl apply -f .\k8s\servicec.yml
kubectl apply -f ..\k8s\apps\staging\nemstore-frontend.yml
kubectl apply -f ..\k8s\apps\staging\nemstore-bff.yml
kubectl apply -f ..\k8s\apps\staging\nemstore-productscatalog.yml