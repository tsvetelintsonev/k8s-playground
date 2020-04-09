.\Build-Docker-Images.ps1

$namespace = kubectl get namespace --all-namespaces=true | Select-String -Pattern "nemstore"

if (!($namespace -match "nemstore")) 
{
    kubectl create -f .\k8s\nemstore-namespace.yml
}

kubectl -n nemstore delete deployment,service --all

# kubectl apply -f .\k8s\webapp.yml
# kubectl apply -f .\k8s\servicea.yml
# kubectl apply -f .\k8s\serviceb.yml
# kubectl apply -f .\k8s\servicec.yml
kubectl apply -f ..\k8s\apps\nemstore-frontend.yml
kubectl apply -f ..\k8s\apps\nemstore-bff.yml
kubectl apply -f ..\k8s\apps\nemstore-productscatalog.yml