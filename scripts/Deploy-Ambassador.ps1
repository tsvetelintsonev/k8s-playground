helm repo add datawire https://www.getambassador.io
helm upgrade --install --wait ambassador datawire/ambassador
kubectl apply -f https://www.getambassador.io/yaml/ambassador/ambassador-rbac.yaml
kubectl apply -f "C:\dev\k8s-playground\k8s\ambassador-gateway.yml"