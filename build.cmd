@ECHO OFF

SETLOCAL

SET SCRIPTPATH=%~dp0
SET SCRIPTPATH=%SCRIPTPATH:~0,-1%

SET SLNNAME=Cyotek.SvnGitMigrate.sln
SET RELDIR=gui\bin\Release\

CD %SCRIPTPATH%

CALL %CTKBLDROOT%\setupEnv.cmd

REM Build and sign the file
%msbuildexe% %SLNNAME% /p:Configuration=Release /verbosity:minimal /nologo /t:Clean,Build

IF EXIST dist RMDIR dist /Q /S

MKDIR dist
MKDIR dist\lib\win32

COPY /y %RELDIR%ctksvnmg.exe                                .\dist
COPY /y %RELDIR%ctksvnmg.exe.config                         .\dist
COPY /y %RELDIR%Cyotek.SvnMigrate.dll                       .\dist
COPY /y %RELDIR%Cyotek.Windows.Forms.TabList.dll            .\dist
COPY /y %RELDIR%DotNet.Glob.dll                             .\dist
COPY /y %RELDIR%LibGit2Sharp.dll                            .\dist
COPY /y %RELDIR%LibGit2Sharp.dll.config                     .\dist
COPY /y %RELDIR%Scriban.Signed.dll                          .\dist
COPY /y %RELDIR%SharpSvn.dll                                .\dist
COPY /y %RELDIR%SharpSvn.UI.dll                             .\dist
COPY /y %RELDIR%SharpPlink-Win32.svnExe                     .\dist
COPY /y %RELDIR%README.md                                   .\dist
COPY /y %RELDIR%CHANGELOG.md                                .\dist
COPY /y %RELDIR%LICENSE.txt                                 .\dist
COPY /y %RELDIR%System.Runtime.CompilerServices.Unsafe.dll  .\dist
COPY /y %RELDIR%System.Threading.Tasks.Extensions.dll       .\dist

XCOPY %RELDIR%lib\win32 .\dist\lib\win32 /E /V /I /Q /H /K

PUSHD .\dist

CALL signcmd ctksvnmg.exe
CALL signcmd Cyotek.SvnMigrate.dll

%zipexe% a Cyotek.SvnGitMigrate.1.x.x.zip -r

POPD

ENDLOCAL
