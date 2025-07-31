# 요구사항 명세 (EARS Notation)

## Ubiquitous Requirements
- THE SYSTEM SHALL Blazor 웹앱에서 Hugging Face MCP 서버와 통합된 AI 이미지 생성 및 텍스트 응답 기능을 제공해야 한다.
- THE SYSTEM SHALL Home 페이지에서 사용자 프롬프트 입력, 추천 프롬프트 버튼, AI 응답(이미지/텍스트) 표시, 대화 히스토리, 로딩/에러 상태를 지원해야 한다.
- THE SYSTEM SHALL Settings 페이지에서 Hugging Face, GitHub Models, Azure OpenAI 설정을 안전하게 관리해야 한다.
- THE SYSTEM SHALL 모든 민감 정보(토큰 등)를 안전하게 저장하고, 앱 재시작 후에도 설정을 유지해야 한다.
- THE SYSTEM SHALL Counter 및 Weather 페이지를 제거하고, Settings 페이지를 네비게이션에 추가해야 한다.
- THE SYSTEM SHALL 데스크톱/모바일 모두에서 반응형 디자인을 지원해야 한다.

## Event-driven Requirements
- WHEN 사용자가 프롬프트를 입력하거나 추천 버튼을 클릭하면, THE SYSTEM SHALL AI 응답(이미지/텍스트)을 받아서 표시해야 한다.
- WHEN AI 응답이 이미지일 경우, THE SYSTEM SHALL 이미지를 적절히 표시하고 다운로드/복사 기능을 제공해야 한다.
- WHEN AI 응답이 텍스트일 경우, THE SYSTEM SHALL 마크다운 형식으로 렌더링해야 한다.
- WHEN 설정이 저장되면, THE SYSTEM SHALL 저장 성공 메시지와 각 서비스별 상태 배지를 표시해야 한다.
- WHEN 네트워크 오류, 잘못된 토큰, Rate Limit 등 에러 발생 시, THE SYSTEM SHALL 사용자에게 명확한 에러 메시지를 표시해야 한다.

## State-driven Requirements
- WHILE AI 응답을 기다리는 중에는, THE SYSTEM SHALL 로딩 인디케이터를 표시해야 한다.
- WHILE MCP 서버가 설정된 경우, THE SYSTEM SHALL MCP 툴 패널을 접을 수 있도록 표시해야 한다.

## Unwanted behavior Requirements
- IF AI Provider가 하나도 설정되지 않은 경우, THEN THE SYSTEM SHALL "No configured AI provider available for chat" 오류를 방지하고, 설정 안내 메시지를 표시해야 한다.
- IF 이미지 로딩 실패, 잘못된 응답 등 발생 시, THEN THE SYSTEM SHALL 사용자에게 재시도 옵션과 에러 메시지를 제공해야 한다.

## Optional Requirements
- WHERE 사용자가 Azure OpenAI와 GitHub Models를 모두 설정한 경우, THE SYSTEM SHALL Azure OpenAI를 우선 사용하고, Fallback으로 GitHub Models를 사용해야 한다.
- WHERE 사용자가 MCP 서버 엔드포인트를 변경한 경우, THE SYSTEM SHALL 해당 엔드포인트로 MCP 클라이언트를 초기화해야 한다.

---

## 요구사항 체크리스트
- [x] Testable: 모든 요구사항은 테스트 케이스로 검증 가능
- [x] Unambiguous: 단일 해석만 가능
- [x] Necessary: 시스템 목적에 부합
- [x] Feasible: .NET Aspire 및 샘플 코드로 실현 가능
- [x] Traceable: 사용자 니즈 및 설계 요소와 연결됨

## 요구사항-컴포넌트 매핑
- Home.razor: AI 인터페이스, 프롬프트 입력, 추천 버튼, 응답 표시, 대화 히스토리, 로딩/에러
- Settings.razor: 토큰/엔드포인트 입력, 저장/상태 표시, UX/보안
- NavMenu.razor: 네비게이션 구조, Settings 추가, AI 브랜딩
- IAIService/AIService: AI Provider 통합, MCP/Azure/GitHub 모델 지원
- IConfigurationService: 안전한 설정 저장/로드, 환경별 처리
- MCP/Azure/GitHub 클라이언트: 각 Provider별 통합 및 오류 처리

---

> 본 문서는 `requirements-specification.md`를 기반으로 EARS 표준에 따라 구조화되었습니다.
