; ModuleID = '.\CPP_SRC\CPP_Main.cpp'
source_filename = ".\\CPP_SRC\\CPP_Main.cpp"
target datalayout = "e-m:w-p270:32:32-p271:32:32-p272:64:64-i64:64-i128:128-f80:128-n8:16:32:64-S128"
target triple = "x86_64-w64-windows-gnu"

@.str.1 = private unnamed_addr constant [17 x i8] c"%.*s \09 U+%04llX\0A\00", align 1
@str = private unnamed_addr constant [18 x i8] c"UTF-8 Codepoints:\00", align 1

; Function Attrs: mustprogress nofree norecurse nosync nounwind willreturn memory(none) uwtable
define dso_local dllexport noundef double @Convert(double noundef %0) local_unnamed_addr #0 {
  %2 = fmul double %0, 0x400921FB54442D18
  %3 = fdiv double %2, 1.800000e+02
  ret double %3
}

; Function Attrs: mustprogress nofree nounwind willreturn memory(write) uwtable
define dso_local dllexport double @Ver(double noundef %0) local_unnamed_addr #1 {
  %2 = tail call double @cos(double noundef %0) #7, !tbaa !5
  %3 = fsub double 1.000000e+00, %2
  ret double %3
}

; Function Attrs: mustprogress nofree nounwind willreturn memory(write)
declare dso_local double @cos(double noundef) local_unnamed_addr #2

; Function Attrs: mustprogress nofree nounwind willreturn memory(write) uwtable
define dso_local dllexport double @Hav(double noundef %0) local_unnamed_addr #1 {
  %2 = tail call double @cos(double noundef %0) #7, !tbaa !5
  %3 = fsub double 1.000000e+00, %2
  %4 = fmul double %3, 5.000000e-01
  ret double %4
}

; Function Attrs: mustprogress nofree norecurse nosync nounwind willreturn memory(none) uwtable
define dso_local dllexport noundef double @DHav(double noundef %0, double noundef %1, double noundef %2, double noundef %3) local_unnamed_addr #0 {
  %5 = fadd double %0, %1
  %6 = fadd double %5, %2
  %7 = fadd double %6, %3
  ret double %7
}

; Function Attrs: mustprogress nofree nounwind willreturn memory(write) uwtable
define dso_local dllexport double @Theta(double noundef %0, i1 noundef zeroext %1) local_unnamed_addr #1 {
  %3 = tail call double @sqrt(double noundef %0) #7, !tbaa !5
  br i1 %1, label %4, label %8

4:                                                ; preds = %2
  %5 = fsub double 1.000000e+00, %0
  %6 = tail call double @sqrt(double noundef %5) #7, !tbaa !5
  %7 = tail call double @atan2(double noundef %3, double noundef %6) #7, !tbaa !5
  br label %10

8:                                                ; preds = %2
  %9 = tail call double @asin(double noundef %3) #7, !tbaa !5
  br label %10

10:                                               ; preds = %8, %4
  %11 = phi double [ %7, %4 ], [ %9, %8 ]
  %12 = fmul double %11, 2.000000e+00
  ret double %12
}

; Function Attrs: mustprogress nofree nounwind willreturn memory(write)
declare dso_local double @atan2(double noundef, double noundef) local_unnamed_addr #2

; Function Attrs: mustprogress nofree nounwind willreturn memory(write)
declare dso_local double @sqrt(double noundef) local_unnamed_addr #2

; Function Attrs: mustprogress nofree nounwind willreturn memory(write)
declare dso_local double @asin(double noundef) local_unnamed_addr #2

; Function Attrs: mustprogress nofree nounwind willreturn memory(write) uwtable
define dso_local dllexport double @Distance(double noundef %0, i1 noundef zeroext %1) local_unnamed_addr #1 {
  %3 = tail call double @sqrt(double noundef %0) #7, !tbaa !5
  br i1 %1, label %4, label %8

4:                                                ; preds = %2
  %5 = fsub double 1.000000e+00, %0
  %6 = tail call double @sqrt(double noundef %5) #7, !tbaa !5
  %7 = tail call double @atan2(double noundef %3, double noundef %6) #7, !tbaa !5
  br label %10

8:                                                ; preds = %2
  %9 = tail call double @asin(double noundef %3) #7, !tbaa !5
  br label %10

10:                                               ; preds = %4, %8
  %11 = phi double [ %7, %4 ], [ %9, %8 ]
  %12 = fmul double %11, 2.000000e+00
  %13 = fmul double %12, 6.371200e+03
  ret double %13
}

; Function Attrs: mustprogress nofree norecurse nosync nounwind willreturn memory(argmem: read) uwtable
define dso_local dllexport range(i64 0, 2097152) i64 @GetUTF8Codepoint(ptr nocapture noundef readonly %0) local_unnamed_addr #3 {
  %2 = load i8, ptr %0, align 1, !tbaa !9
  %3 = zext i8 %2 to i32
  %4 = icmp sgt i8 %2, -1
  br i1 %4, label %5, label %7

5:                                                ; preds = %1
  %6 = zext nneg i8 %2 to i64
  br label %61

7:                                                ; preds = %1
  %8 = and i32 %3, 224
  %9 = icmp eq i32 %8, 192
  br i1 %9, label %10, label %19

10:                                               ; preds = %7
  %11 = shl nuw nsw i32 %3, 6
  %12 = and i32 %11, 1984
  %13 = getelementptr inbounds nuw i8, ptr %0, i64 1
  %14 = load i8, ptr %13, align 1, !tbaa !9
  %15 = and i8 %14, 63
  %16 = zext nneg i8 %15 to i32
  %17 = or disjoint i32 %12, %16
  %18 = zext nneg i32 %17 to i64
  br label %61

19:                                               ; preds = %7
  %20 = and i32 %3, 240
  %21 = icmp eq i32 %20, 224
  br i1 %21, label %22, label %37

22:                                               ; preds = %19
  %23 = shl nuw nsw i32 %3, 12
  %24 = and i32 %23, 61440
  %25 = getelementptr inbounds nuw i8, ptr %0, i64 1
  %26 = load i8, ptr %25, align 1, !tbaa !9
  %27 = and i8 %26, 63
  %28 = zext nneg i8 %27 to i32
  %29 = shl nuw nsw i32 %28, 6
  %30 = or disjoint i32 %29, %24
  %31 = getelementptr inbounds nuw i8, ptr %0, i64 2
  %32 = load i8, ptr %31, align 1, !tbaa !9
  %33 = and i8 %32, 63
  %34 = zext nneg i8 %33 to i32
  %35 = or disjoint i32 %30, %34
  %36 = zext nneg i32 %35 to i64
  br label %61

37:                                               ; preds = %19
  %38 = and i32 %3, 248
  %39 = icmp eq i32 %38, 240
  br i1 %39, label %40, label %61

40:                                               ; preds = %37
  %41 = shl nuw nsw i32 %3, 18
  %42 = and i32 %41, 1835008
  %43 = getelementptr inbounds nuw i8, ptr %0, i64 1
  %44 = load i8, ptr %43, align 1, !tbaa !9
  %45 = and i8 %44, 63
  %46 = zext nneg i8 %45 to i32
  %47 = shl nuw nsw i32 %46, 12
  %48 = or disjoint i32 %47, %42
  %49 = getelementptr inbounds nuw i8, ptr %0, i64 2
  %50 = load i8, ptr %49, align 1, !tbaa !9
  %51 = and i8 %50, 63
  %52 = zext nneg i8 %51 to i32
  %53 = shl nuw nsw i32 %52, 6
  %54 = or disjoint i32 %48, %53
  %55 = getelementptr inbounds nuw i8, ptr %0, i64 3
  %56 = load i8, ptr %55, align 1, !tbaa !9
  %57 = and i8 %56, 63
  %58 = zext nneg i8 %57 to i32
  %59 = or disjoint i32 %54, %58
  %60 = zext nneg i32 %59 to i64
  br label %61

61:                                               ; preds = %10, %37, %40, %22, %5
  %62 = phi i64 [ %6, %5 ], [ %18, %10 ], [ %36, %22 ], [ %60, %40 ], [ 0, %37 ]
  ret i64 %62
}

; Function Attrs: mustprogress nofree nounwind uwtable
define dso_local dllexport void @RawUTF8Print(ptr noundef %0) local_unnamed_addr #4 {
  %2 = tail call i32 @puts(ptr nonnull dereferenceable(1) @str)
  %3 = load i8, ptr %0, align 1, !tbaa !9
  %4 = icmp eq i8 %3, 0
  br i1 %4, label %80, label %5

5:                                                ; preds = %1, %72
  %6 = phi i8 [ %78, %72 ], [ %3, %1 ]
  %7 = phi ptr [ %77, %72 ], [ %0, %1 ]
  %8 = zext i8 %6 to i32
  %9 = icmp sgt i8 %6, -1
  br i1 %9, label %22, label %10

10:                                               ; preds = %5
  %11 = and i32 %8, 224
  %12 = icmp eq i32 %11, 192
  br i1 %12, label %24, label %13

13:                                               ; preds = %10
  %14 = and i32 %8, 240
  %15 = icmp eq i32 %14, 224
  %16 = and i32 %8, 248
  %17 = icmp eq i32 %16, 240
  %18 = select i1 %17, i32 4, i32 1
  %19 = select i1 %15, i32 3, i32 %18
  %20 = and i32 %8, 240
  %21 = icmp eq i32 %20, 224
  br i1 %21, label %33, label %48

22:                                               ; preds = %5
  %23 = zext nneg i8 %6 to i64
  br label %72

24:                                               ; preds = %10
  %25 = shl nuw nsw i32 %8, 6
  %26 = and i32 %25, 1984
  %27 = getelementptr inbounds nuw i8, ptr %7, i64 1
  %28 = load i8, ptr %27, align 1, !tbaa !9
  %29 = and i8 %28, 63
  %30 = zext nneg i8 %29 to i32
  %31 = or disjoint i32 %26, %30
  %32 = zext nneg i32 %31 to i64
  br label %72

33:                                               ; preds = %13
  %34 = shl nuw nsw i32 %8, 12
  %35 = and i32 %34, 61440
  %36 = getelementptr inbounds nuw i8, ptr %7, i64 1
  %37 = load i8, ptr %36, align 1, !tbaa !9
  %38 = and i8 %37, 63
  %39 = zext nneg i8 %38 to i32
  %40 = shl nuw nsw i32 %39, 6
  %41 = or disjoint i32 %40, %35
  %42 = getelementptr inbounds nuw i8, ptr %7, i64 2
  %43 = load i8, ptr %42, align 1, !tbaa !9
  %44 = and i8 %43, 63
  %45 = zext nneg i8 %44 to i32
  %46 = or disjoint i32 %41, %45
  %47 = zext nneg i32 %46 to i64
  br label %72

48:                                               ; preds = %13
  %49 = and i32 %8, 248
  %50 = icmp eq i32 %49, 240
  br i1 %50, label %51, label %72

51:                                               ; preds = %48
  %52 = shl nuw nsw i32 %8, 18
  %53 = and i32 %52, 1835008
  %54 = getelementptr inbounds nuw i8, ptr %7, i64 1
  %55 = load i8, ptr %54, align 1, !tbaa !9
  %56 = and i8 %55, 63
  %57 = zext nneg i8 %56 to i32
  %58 = shl nuw nsw i32 %57, 12
  %59 = or disjoint i32 %58, %53
  %60 = getelementptr inbounds nuw i8, ptr %7, i64 2
  %61 = load i8, ptr %60, align 1, !tbaa !9
  %62 = and i8 %61, 63
  %63 = zext nneg i8 %62 to i32
  %64 = shl nuw nsw i32 %63, 6
  %65 = or disjoint i32 %59, %64
  %66 = getelementptr inbounds nuw i8, ptr %7, i64 3
  %67 = load i8, ptr %66, align 1, !tbaa !9
  %68 = and i8 %67, 63
  %69 = zext nneg i8 %68 to i32
  %70 = or disjoint i32 %65, %69
  %71 = zext nneg i32 %70 to i64
  br label %72

72:                                               ; preds = %22, %24, %33, %48, %51
  %73 = phi i32 [ 1, %22 ], [ 2, %24 ], [ %19, %33 ], [ %19, %51 ], [ %19, %48 ]
  %74 = phi i64 [ %23, %22 ], [ %32, %24 ], [ %47, %33 ], [ %71, %51 ], [ 0, %48 ]
  %75 = tail call i32 (ptr, ...) @printf(ptr noundef nonnull dereferenceable(1) @.str.1, i32 noundef %73, ptr noundef nonnull %7, i64 noundef %74)
  %76 = zext nneg i32 %73 to i64
  %77 = getelementptr inbounds nuw i8, ptr %7, i64 %76
  %78 = load i8, ptr %77, align 1, !tbaa !9
  %79 = icmp eq i8 %78, 0
  br i1 %79, label %80, label %5, !llvm.loop !10

80:                                               ; preds = %72, %1
  ret void
}

; Function Attrs: nofree nounwind
declare dso_local noundef i32 @printf(ptr nocapture noundef readonly, ...) local_unnamed_addr #5

; Function Attrs: nofree nounwind
declare noundef i32 @puts(ptr nocapture noundef readonly) local_unnamed_addr #6

attributes #0 = { mustprogress nofree norecurse nosync nounwind willreturn memory(none) uwtable "min-legal-vector-width"="0" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cmov,+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #1 = { mustprogress nofree nounwind willreturn memory(write) uwtable "min-legal-vector-width"="0" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cmov,+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #2 = { mustprogress nofree nounwind willreturn memory(write) "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cmov,+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #3 = { mustprogress nofree norecurse nosync nounwind willreturn memory(argmem: read) uwtable "min-legal-vector-width"="0" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cmov,+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #4 = { mustprogress nofree nounwind uwtable "min-legal-vector-width"="0" "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cmov,+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #5 = { nofree nounwind "no-trapping-math"="true" "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cmov,+cx8,+fxsr,+mmx,+sse,+sse2,+x87" "tune-cpu"="generic" }
attributes #6 = { nofree nounwind }
attributes #7 = { nounwind }

!llvm.module.flags = !{!0, !1, !2, !3}
!llvm.ident = !{!4}

!0 = !{i32 1, !"wchar_size", i32 2}
!1 = !{i32 8, !"PIC Level", i32 2}
!2 = !{i32 7, !"uwtable", i32 2}
!3 = !{i32 1, !"MaxTLSAlign", i32 65536}
!4 = !{!"clang version 20.1.0 (https://github.com/llvm/llvm-project.git 24a30daaa559829ad079f2ff7f73eb4e18095f88)"}
!5 = !{!6, !6, i64 0}
!6 = !{!"int", !7, i64 0}
!7 = !{!"omnipotent char", !8, i64 0}
!8 = !{!"Simple C++ TBAA"}
!9 = !{!7, !7, i64 0}
!10 = distinct !{!10, !11}
!11 = !{!"llvm.loop.mustprogress"}
