$path = D:\progect
$foldersToDelete = @("bin", "obj")

Get-ChildItem -Path $path -Directory -Recurse | Where-Object {
    $foldersToDelete -contains $_.Name
} | Remove-Item -Recurse -Force -Verbose