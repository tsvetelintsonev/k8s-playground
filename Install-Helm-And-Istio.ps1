choco install kubernetes-helm --version 2.16.1
helm install --name istio-init --namespace istio-system istio.io/istio-init
helm install --name istio --namespace istio-system --set grafana.enabled=true istio.io/istio
kubectl label namespace k8s-playground istio-injection=enabled
