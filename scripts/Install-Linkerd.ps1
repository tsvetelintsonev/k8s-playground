$linkerdFolder = "c:/dev/k8s/linkerd"
Invoke-WebRequest -Uri "https://github.com/linkerd/linkerd2/releases/download/edge-20.4.1/linkerd2-cli-edge-20.4.1-windows.exe" -OutFile "$linkerdFolder/linkerd.exe"
$Env:path += ";$linkerdFolder"

linkerd check --pre
linkerd install | kubectl apply -f -
linkerd check
linkerd dashboard