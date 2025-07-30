# WORKLOG


## 박태영, 프로젝트 템플릿 생성

- [x] 프로젝트를 생성한다: `dotnet new aspire-starter -n WebApp -o ./src`

## 코파일럿, 요구사항 기반 전체 작업계획

- [x] Home 페이지를 AI 인터페이스로 리팩터링 (입력창, 추천 프롬프트, 응답/이미지/채팅 히스토리/로딩/에러 처리)
- [ ] Settings 페이지 신규 구현 및 보안 설정 관리 (필수/선택 필드, UX, 저장/배지/피드백/유효성검사)
- [ ] 네비게이션 업데이트 (Counter/Weather 제거, Settings 추가, AI 브랜딩, 반응형 디자인)
- [ ] NuGet 패키지 설치 및 버전 정렬 (Microsoft.Extensions.AI, Azure.AI.Inference, Azure.AI.OpenAI, ModelContextProtocol.Client, System.ClientModel)
- [ ] AI 서비스 레이어 구현 (IAIService, AIService, MCP/Azure OpenAI/GitHub Models 통합, 이미지/텍스트 응답, 우선순위/폴백)
- [ ] 설정 서비스 구현 (IConfigurationService, 보안 저장/조회, 환경별 지원, 최소 1개 AI Provider+Hugging Face 검증)
- [ ] Azure OpenAI 연동 (엔드포인트/API키 인증, 배포 기반 모델 호출, 에러 처리)
- [ ] MCP 연동 (클라이언트 초기화, 툴 탐색/호출, 에러/재시도 처리)
- [ ] 응답 처리 (이미지/텍스트/마크다운/스트리밍 UX)
- [ ] Home/Settings 페이지 UX 개선 (입력/이미지/복사/구분/저장/에러/빠른설정)
- [ ] 에러 처리 및 유효성 검사 (네트워크, 토큰, 레이트리밋, 응답, 이미지, 설정)
- [ ] 보안 강화 (토큰 미로그, CORS, HTTPS, 입력검증, 레이트리밋, 데이터보호)
- [ ] 테스트 작성 (단위/통합/UI/설정/에러 시나리오)

#### Home 페이지 AI 인터페이스 리팩터링 세부 작업계획
 - [x] 기존 Home.razor 파일 구조 및 코드 분석
 - [x] Home.razor 내 Counter/Weather 관련 코드 및 UI 제거
 - [x] 사용자 프롬프트 입력창 및 추천 프롬프트 버튼 UI 추가
 - [x] AI 응답(텍스트/이미지) 표시 컴포넌트 설계 및 구현
 - [x] 채팅 히스토리 UI 및 데이터 구조 설계
 - [x] 로딩 상태 및 에러 메시지 UI 구현
 - [x] AI 서비스 호출 코드(Stub) 연결
 - [x] 반응형 및 현대적 디자인 적용

#### Settings 페이지 세부 작업계획
- [x] Settings.razor 기본 UI 및 라우트 생성
- [x] 필수/선택 설정 필드 설계 및 입력 폼 구현
- [x] 저장/적용 버튼 및 UX 피드백 처리
- [x] 배지/상태 표시 UI
- [x] 입력값 유효성 검사 및 에러 처리
- [x] 설정값 저장/불러오기(보안 저장)
- [x] AI Provider 선택 및 환경별 지원
- [x] 빠른설정/초기화 기능
- [x] 반응형 디자인 및 접근성 개선

### 기타 유지보수 및 정리 작업
- [ ] Weather, Counter 컴포넌트 파일 완전 삭제