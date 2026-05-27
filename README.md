### Codegen:

#### [Program.CallerMethodWithConstants()](https://github.com/budgetdevv/IsKnownConstant/blob/cf134e80b627a69551daea41d18951cc35f044c6/IsKnownConstant/Program.cs#L17)

As shown, the `RuntimeHelpers.IsKnownConstant()` we hijacked is able to detect that the argument passed into InlinedMethod()
are actually constants. As such, constant folding is able to kick in and optimize `Program.CallerMethodWithConstants()`
just ret true

```asm
Preparing to JIT-compile methods matching pattern: IsKnownConstant.Program:CallerMethodWithConstants()
JIT-compiling method: Boolean CallerMethodWithConstants()
; Assembly listing for method IsKnownConstant.Program:CallerMethodWithConstants():bool (FullOpts)
; Emitting BLENDED_CODE for x64 + VEX on Unix
; FullOpts code
; optimized code
; rsp based frame
; partially interruptible
; No PGO data
; 0 inlinees with PGO data; 12 single block inlinees; 0 inlinees without PGO data

G_M000_IG01:
 
G_M000_IG02:
       mov      eax, 1
 
G_M000_IG03:
       ret      
 
; Total bytes of code 6
```

