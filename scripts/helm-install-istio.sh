cd c:/dev/k8s
curl -L https://istio.io/downloadIstio | ISTIO_VERSION=1.5.1 sh -
cd istio-1.5.1
export PATH=$PWD/bin:$PATH
helm install ./install/kubernetes/helm/istio-init --name istio-init --namespace istio-system
helm install ./install/kubernetes/helm/istio --name istio --namespace istio-system --set grafana.enabled=true,kiali.enabled=true,tracing.enabled=true
kubectl label namespace nemstore istio-injection=enabled
