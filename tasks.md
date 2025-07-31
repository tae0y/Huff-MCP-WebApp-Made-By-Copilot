# 구현 계획 (Implementation Tasks)

| Task ID | Description | Expected Outcome | Dependencies | Status |
|--------|-------------|------------------|--------------|--------|
| T1 | Home.razor: AI 인터페이스, 프롬프트 입력, 추천 버튼, 응답(이미지/텍스트), 대화 히스토리, MCP 툴 패널, 로딩/에러 UI 구현 | 사용자가 프롬프트 입력 및 추천 버튼으로 AI 응답(이미지/텍스트) 수신, 대화 기록, 툴 패널, UX 개선 | requirements.md, design.md | TODO |
| T2 | Settings.razor: 토큰/엔드포인트 입력, 저장/상태 배지, UX/보안, User Secrets/암호화 적용 | 사용자가 안전하게 설정 입력/저장, 상태 확인, 보안/UX 만족 | T1 | TODO |
| T3 | NavMenu.razor: Counter/Weather 제거, Settings 추가, AI 브랜딩, 반응형 네비게이션 | 네비게이션에서 불필요 페이지 제거, Settings 추가, AI 중심 UX | T1 | TODO |
| T4 | IAIService/AIService: MCP/Azure/GitHub Provider 통합, 이미지/텍스트 응답, 우선순위/재시도/오류 처리 | 다양한 Provider 지원, 이미지/텍스트 응답, 오류/재시도/우선순위 처리 | T1, T2 | TODO |
| T5 | IConfigurationService: 안전한 설정 저장/로드, 환경별 처리, 입력 검증/암호화 | 설정이 안전하게 저장/로드, 환경별 동작, 입력 검증/암호화 | T2 | TODO |
| T6 | NuGet 패키지 설치 및 버전 정렬 (Microsoft.Extensions.AI, Azure.AI.Inference, ModelContextProtocol.Client 등) | 모든 기능에 필요한 패키지 설치 및 버전 호환 | T1-T5 | TODO |
| T7 | 단위/통합/UI 테스트: 주요 기능, Provider, 설정, 오류/에러/보안/UX 테스트 | 모든 요구사항에 대한 테스트 케이스 통과 | T1-T6 | TODO |
| T8 | 문서화 및 인수인계 자료 정리: 요구/설계/테스트/사용법 최신화 | 최신 문서화 및 인수인계 자료 제공 | 전체 | TODO |

---

> 본 문서는 `requirements.md`, `design.md`를 기반으로 작성된 구현 계획입니다. 각 작업 완료 시 Status를 실시간으로 업데이트하세요.
