# 🦖 DontGetExtinct

> "너도 멸종되지 않게 조심해."

Unity 2D 기반 생존 액션 게임  
25-1 컴퓨터 그래픽스 기말 프로젝트

## 🎥 Gameplay Video
[![DontGetExtinct Gameplay](https://img.youtube.com/vi/KJXvrQpCN_w/0.jpg)](https://youtu.be/KJXvrQpCN_w)

---

## 🎮 About The Game

**DontGetExtinct**는 인터넷 밈 *‘공룡 멸종 정식’*에서 영감을 받아 제작한  
2D 생존형 아케이드 게임입니다.

플레이어는 공룡 캐릭터를 조작하여  
하늘에서 떨어지는 **미트볼(운석)**을 피하고  
**정해진 순서대로 등장하는 별을 수집**하여  
멸종되지 않고 생존해야 합니다.

---

## 🕹 Gameplay Flow

- **ReadyScene** : 시작 화면 + 게임 가이드
- **GameScene** : 본 게임 플레이
- **ClearScene** : 별 5개 수집 시
- **OverScene** : 하트 3개 소진 시

---

## ✨ Core Features

### 🎯 Player Movement
- Rigidbody2D 기반 좌우 이동
- 화면 이탈 방지 처리
- 충돌 판정 시스템

### ☄ Falling Meatballs
- 랜덤 위치에서 낙하
- 충돌 시 체력 감소
- 점수 감소 + 효과음

### ⭐ Star Collection System
- 정해진 순서 기반 등장
- 충돌 시 점수 증가
- UI 실시간 반영

### ❤️ Health System
- 초기 하트 3개
- 모두 소진 시 Game Over

### 📊 Score System
- 플레이 시간 기반 점수 증가
- 별 수집 보너스 점수
- 점수 애니메이션 연출

---

## 🧩 Object & Script Architecture

| Object | Script | Responsibility |
|--------|--------|---------------|
| Player | PlayerController | 이동, 화면 제한, 애니메이션 |
| Meatball | ItemController | 낙하, 충돌 처리 |
| Star | ItemController | 순서 기반 등장, 점수 처리 |
| ItemGenerator | ItemGenerator | 아이템 생성 로직 |
| GameManager | GameManager | 게임 상태 및 UI 관리 |

---

## 🎨 UI & Effects

- ⭐ 별 슬롯 UI
- ❤️ 하트 UI
- 📊 점수 UI
- 🎵 Scene별 BGM 자동 재생
- 🔊 충돌 시 SFX
- 📝 게임 가이드 팝업

---

## 🛠 Tech Stack

- **Engine** : Unity (2D)
- **Language** : C#
- **Physics** : Rigidbody2D / Collider2D
- **Scene Management** : Unity Scene System
- **Audio** : BGM & SFX
