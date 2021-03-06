$linkerdFolder = "c:/dev/k8s/linkerd"

Write-Host "Downloading linkerd"
Invoke-WebRequest -Uri "https://github.com/linkerd/linkerd2/releases/download/edge-20.4.1/linkerd2-cli-edge-20.4.1-windows.exe" -OutFile "$linkerdFolder/linkerd.exe"
Write-Host "Finished downloading linkerd"

Write-Host "Adding linkerd binary to PATH"
$env:Path += ";$linkerdFolder"
Write-Host "Finished adding linkerd binary to PATH"

Write-Host "Installing linkerd"
linkerd check --pre
linkerd install | kubectl apply -f -
linkerd check
Write-Host "Finished installing linkerd"

Write-Host "Launching linkerd dashboard"
linkerd dashboard