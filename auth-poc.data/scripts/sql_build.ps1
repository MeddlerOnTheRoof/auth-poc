$scripttype = "implementation" # implementation  rollback 
$dbserver = "localhost\MSSQLSERVER01"

$dbname = "authpoc"

$currentpath = $PSScriptRoot

$implpath = $currentpath + "\configuration\implementation.txt"
$rollbackpath = $currentpath + "\configuration\rollback.txt"

if ($scripttype -eq "implementation")
{
    $files = Get-Content $implpath
    $path = $currentpath + "\implementation\"
}

if ($scripttype -eq "rollback")
{
    $files = Get-Content $rollbackpath
    $path = $currentpath + "\rollback\"
}

$timestamp = Get-Date -Format yyyymmdd.H.m.s

$logfile =  $currentpath + "\logs\" + $timestamp + ".log"
$timestamp | Out-File $logfile -Append

Foreach ($file in $files)
{
    $fullfilepath = $path + $file
    $timestamp = Get-Date -Format yyyymmdd.H.m.s
    $timestamp + " | " + $file | Out-File $logfile -Append
    Invoke-Sqlcmd -InputFile $fullfilepath -ServerInstance $dbserver -Database $dbname -OutputSqlErrors $true -Verbose *>> $logfile
    
    #Invoke-Sqlcmd -InputFile $fullfilepath -ServerInstance $dbserver -Username $username -Password $password -Database $dbname -OutputSqlErrors $true -Verbose *>> $logfile
    
    "" | Out-File $logfile -Append
}
