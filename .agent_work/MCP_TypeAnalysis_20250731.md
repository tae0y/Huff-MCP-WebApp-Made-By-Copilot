### Action - MCP SDK 타입/네임스페이스 오류 분석 - 2025-07-31
**Objective**: AIService.cs의 MCP 관련 타입 컴파일 오류 원인 분석 및 공식 샘플 기반 네임스페이스/타입명 확인
**Context**: ModelContextProtocol 패키지(v0.3.0-preview.3) 설치 후, AIService.cs에서 McpClient, SseClientTransport, McpClientFactory, ChatOptions 등 타입을 참조하나 모두 "형식 또는 네임스페이스 이름을 찾을 수 없습니다" 오류 발생
**Decision**: 공식 Microsoft 샘플(GitHub)에서 실제 타입명과 네임스페이스를 확인하여 코드에 반영하기로 결정
**Execution**: 1) 샘플 코드에서 MCP 클라이언트 초기화 및 사용 패턴 확인, 2) 필요한 using 지시문 및 타입명 정리, 3) AIService.cs에 적용 예정
**Output**: 오류 목록 및 샘플 기반 네임스페이스/타입명 분석 결과
**Validation**: 샘플 코드와 패키지 문서에서 타입명/네임스페이스 일치 여부 확인, 적용 후 컴파일 성공 여부로 검증
**Next**: 샘플 기반으로 AIService.cs의 using 및 타입명 수정, 컴파일 오류 해결
