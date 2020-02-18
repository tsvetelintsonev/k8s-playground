.\Build-Docker-Images.ps1

$namespace = kubectl get namespace -A | Select-String -Pattern "k8s-playground"

if (!($namespace -match "k8s-playground")) 
{
    kubectl create -f .\k8s\namespace.yml
}

kubectl -n k8s-playground delete deployment,virtualservice,gateway --all

kubectl apply -f .\k8s\webapp.yml
kubectl apply -f .\k8s\servicea.yml
kubectl apply -f .\k8s\serviceb.yml
kubectl apply -f .\k8s\servicec.yml

kubectl apply -f .\k8s\grafana.yml