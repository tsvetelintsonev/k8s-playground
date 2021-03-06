$istioVersion = "1.5.1"
$istioFolder = "c:/dev/k8s/istio"
New-Item -Path "c:/dev/k8s" -Name "istio" -ItemType "directory"
Invoke-WebRequest -Uri "https://github.com/istio/istio/releases/download/$istioVersion/istio-$istioVersion-win.zip" -OutFile "$istioFolder/istio-$istioVersion-win.zip"
Expand-Archive -LiteralPath "$istioFolder/istio-$istioVersion-win.zip" -DestinationPath "$istioFolder"
$Env:path += ";$istioFolder/istio-$istioVersion/bin"
Remove-Item "$istioFolder/istio-$istioVersion-win.zip"

istioctl operator init
kubectl create ns istio-system

New-Item -Path $istioFolder -Name "istiocontrolplane.yml" -ItemType "file" -Value @"
apiVersion: install.istio.io/v1alpha1
kind: IstioOperator
metadata:
  namespace: istio-system
  name: istiocontrolplane
spec:
  profile: default
  components:
    base:
      enabled: true
    proxy:
      enabled: true
    pilot:
      enabled: true
    sidecarInjector:
      enabled: true
    telemetry:
      enabled: true
    policy:
      enabled: true
    citadel:
      enabled: true
    galley:
      enabled: true
    egressGateways:
    - enabled: true
      name: istio-egressgateway
  addonComponents:
    grafana:
      enabled: true
    kiali:
      enabled: true
    prometheus:
      enabled: true
    tracing:
      enabled: true
"@

kubectl apply -f "$istioFolder/istiocontrolplane.yml"
kubectl label namespace nemstore-dev istio-injection=enabled