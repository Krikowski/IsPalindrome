# Palindrome Checker in C# - By Debora Weber Krikowski

A simple yet extensible palindrome checker built with a focus on **clean code principles** and **performance optimizations**.

---

## 📌 Project Overview

This project checks whether a given string is a palindrome, going beyond the basic solution by applying good software engineering practices.

---

## ✅ Key Concepts Applied

- **Dependency Injection (DI):**  
  The string cleaning logic is injected, allowing future extensions or custom implementations.

- **Single Responsibility Principle (SRP):**  
  The palindrome checker class is focused solely on palindrome verification.  
  String cleaning logic is encapsulated in a separate class.

- **Unicode Normalization:**  
  Supports input strings with accents, punctuation, and spaces using Unicode FormD decomposition and filtering.

- **Performance Optimization:**  
  Uses `Span<T>` and `stackalloc` to reverse strings without creating unnecessary heap allocations.

- **Extensible Architecture:**  
  Ready to support custom string cleaning strategies (e.g., emoji filters, language-specific rules).

---

## 📎 Example Input and Output

```csharp
Input: "A man, a plan, a canal: Panama"
Output: It's a palindrome!

Input: "race a car"
Output: Not a palindrome.
