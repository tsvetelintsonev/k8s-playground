$namespace = kubectl get namespace --all-namespaces=true | Select-String -Pattern "nemstore-prod"

if (!($namespace -match "nemstore-prod")) 
{
    kubectl create -f ..\k8s\nemstore-prod-namespace.yml
}

kubectl -n nemstore-prod delete deployment,service --all

# kubectl apply -f .\k8s\webapp.yml
# kubectl apply -f .\k8s\servicea.yml
# kubectl apply -f .\k8s\serviceb.yml
# kubectl apply -f .\k8s\servicec.yml
kubectl apply -f ..\k8s\apps\prod\nemstore-frontend.yml
kubectl apply -f ..\k8s\apps\prod\nemstore-bff.yml
kubectl apply -f ..\k8s\apps\prod\nemstore-productscatalog.yml