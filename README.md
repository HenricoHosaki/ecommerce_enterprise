# Enterprise E-commerce Gateway (.NET 10 & Node.js AI Microservices)

A production-grade, enterprise-level microservices architecture implementing the **Transactional Outbox Pattern**, **Event-Driven Architecture**, and **AI-powered Risk Assessment** using a local static rules specification.

---

## 🏗️ Architecture Overview

1. **API Ingress (.NET 10 + Clean Architecture):** 
   - Accepts customer registrations and initial orders via REST (`POST /api/v1/customers`).
   - Executes an atomic database transaction using EF Core, writing the Customer, Order, and an **Outbox Message** simultaneously.
2. **Reliable Dispatcher (Outbox Publisher Worker):**
   - Background service polling the database for pending outbox events and publishing them to **Google Cloud Pub/Sub**.
3. **Async Consumer & AI Risk Engine (Node.js + TypeScript):**
   - Consumes events from the Pub/Sub queue.
   - Evaluates risk compliance using a static Markdown specification file (`business-rules.md`) injected into the evaluation context, avoiding unnecessary LLM tool-calling roundtrips and optimizing token usage.
   - Updates the PostgreSQL database (`ACTIVE` / `REJECTED`) within a transactional boundary.
   - Routes failed messages to a **Dead-Letter Queue (DLQ)** to keep production data clean.

---

## 🛠️ Technology Stack

- **Backend API:** .NET 10, C#, Entity Framework Core, PostgreSQL, LINQ.
- **Worker & Processing:** Node.js, TypeScript, Google Cloud Pub/Sub SDK, node-postgres (`pg`).
- **Infrastructure:** Docker Compose, PostgreSQL 16 Alpine, GCP Pub/Sub Local Emulator.
- **Design Patterns:** Transactional Outbox Pattern, Clean Architecture, Background Worker.

---

## 🚀 Quick Start (Local Environment)

### 1. Clone & Start Infrastructure
Ensure Docker is running, then start PostgreSQL and the Pub/Sub emulator:
```bash
docker compose up -d
