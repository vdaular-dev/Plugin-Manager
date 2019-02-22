# Plugin-Manager
## 출처
이 코드는 [Code Project](https://www.codeproject.com/Articles/8832/Plug-in-Manager)에서 필요한 기능을 추가한 것입니다.

문제가 발생할 시에 삭제될 수 있습니다.

기능을 추가를 원하시면 이슈나 메일에 주시면, 수정하여 Commit 하겠습니다.

---
## 설명
```
AppDomain을 새롭게 생성하고, 생성된 곳에 DLL을 동적 로딩합니다. 
Plugin Manager를 Stop하면 AppDomain을 언로드 함으로 C# DLL 정적 로딩할 시에 메모리 문제점을 해결하였습니다.
```
