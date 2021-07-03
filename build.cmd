@ECHO OFF

SETLOCAL

SET SCRIPTPATH=%~dp0
SET SCRIPTPATH=%SCRIPTPATH:~0,-1%

SET SLNNAME=Cyotek.SvnGitMigrate.sln
SET RELDIR=gui\bin\Release\

CD %SCRIPTPATH%

CALL %CTKBLDROOT%setupEnv.cmd

REM Build and sign the file
%msbuildexe% %SLNNAME% /p:Configuration=Release /verbosity:minimal /nologo /t:Clean,Build

IF EXIST dist RMDIR dist /Q /S

IF NOT EXIST dist MKDIR dist

COPY /y %RELDIR%ctksvnmg.exe                      .\dist\ctksvnmg.exe
COPY /y %RELDIR%ctksvnmg.exe.config               .\dist\ctksvnmg.exe.config
COPY /y %RELDIR%Cyotek.SvnMigrate.dll             .\dist\Cyotek.SvnMigrate.dll
COPY /y %RELDIR%Cyotek.SvnMigrate.dll             .\dist\Cyotek.SvnMigrate.dll
COPY /y %RELDIR%Cyotek.Windows.Forms.TabList.dll  .\dist\Cyotek.Windows.Forms.TabList.dll
COPY /y %RELDIR%DotNet.Glob.dll                   .\dist\DotNet.Glob.dll
COPY /y %RELDIR%LibGit2Sharp.dll                  .\dist\LibGit2Sharp.dll
COPY /y %RELDIR%LibGit2Sharp.dll.config           .\dist\LibGit2Sharp.dll.config
COPY /y %RELDIR%SharpSvn.dll                      .\dist\SharpSvn.dll
COPY /y %RELDIR%SharpSvn.UI.dll                   .\dist\SharpSvn.UI.dll
COPY /y %RELDIR%SharpPlink-Win32.svnExe           .\dist\SharpPlink-Win32.svnExe

XCOPY %RELDIR%lib .\dist\lib /E /V /I /Q /H /K

PUSHD .\dist

CALL signcmd ctksvnmg.exe
CALL signcmd Cyotek.SvnMigrate.dll

%zipexe% a Cyotek.SvnGitMigrate.1.x.x.zip -r

POPD

ENDLOCAL
