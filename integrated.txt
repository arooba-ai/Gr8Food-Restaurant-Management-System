; =====================================================================
; Integrated Shape Generation System
; CT124-3-1-ICS Group Project
;
; Members:
;   - Triangle Generator
;   - Rectangle Generator  (Abeer Al Hassan, TP108997)
;   - Square Generator
;   - Diamond Generator
;
; Assemble & link (32-bit Linux):
;   nasm -f elf32 integrated.asm -o integrated.o
;   ld -m elf_i386 integrated.o -o integrated
;   ./integrated
; =====================================================================

; =====================================================================
; SECTION .DATA
; =====================================================================
section .data

    ; ------------------------------------------------------------------
    ; Main Menu
    ; ------------------------------------------------------------------
    menu_header     db 10
                    db "================================", 10
                    db "    SHAPE GENERATION SYSTEM     ", 10
                    db "================================", 10
                    db "1. Triangle Generator", 10
                    db "2. Rectangle Generator", 10
                    db "3. Square Generator", 10
                    db "4. Diamond Generator", 10
                    db "5. Exit", 10
                    db "--------------------------------", 10
                    db "Enter your choice: "
    menu_header_len equ $ - menu_header

    menu_err        db 10, "Invalid choice! Please enter 1-5.", 10
    menu_err_len    equ $ - menu_err

    ; ------------------------------------------------------------------
    ; Triangle Generator data
    ; (renamed: prompt->tri_prompt, err_msg->tri_err_msg,
    ;           star->tri_star, newline->tri_newline)
    ; ------------------------------------------------------------------
    tri_prompt      db "Enter the height of the triangle (1-9): "
    tri_prompt_len  equ $ - tri_prompt

    tri_err_msg     db "Error: Invalid input. Must be between 1 and 9.", 10
    tri_err_len     equ $ - tri_err_msg

    tri_star        db "*"
    tri_newline     db 10

    ; ------------------------------------------------------------------
    ; Rectangle Generator data
    ; (renamed: prompt_width->rect_prompt_width, star->rect_star,
    ;           space->rect_space, newline->rect_newline, buf->rect_buf)
    ; ------------------------------------------------------------------
    rect_prompt_width   db "Enter rectangle width  (1-40): ", 0
    rect_prompt_height  db "Enter rectangle height (1-20): ", 0
    rect_prompt_fill    db "Fill style - (f)illed or (o)utlined: ", 0
    rect_invalid_num    db "Error: invalid number. Width must be 1-40, height 1-20.", 10, 0
    rect_star           db "*"
    rect_space          db " "
    rect_newline        db 10, 0

    ; ------------------------------------------------------------------
    ; Square Generator data
    ; (renamed: msg1->sq_msg1, newline->sq_newline, space->sq_space,
    ;           symbol->sq_symbol, invalid->sq_invalid,
    ;           invalidLen->sq_invalidLen)
    ; ------------------------------------------------------------------
    sq_msg1         db "Enter square size (1-9): "
    sq_len1         equ $ - sq_msg1

    sq_msg2         db 10, "Choose symbol:", 10
                    db "1. *", 10
                    db "2. #", 10
                    db "3. @", 10
                    db "Enter choice: "
    sq_len2         equ $ - sq_msg2

    sq_msg3         db 10, "Choose square type:", 10
                    db "1. Filled Square", 10
                    db "2. Hollow Square", 10
                    db "Enter choice: "
    sq_len3         equ $ - sq_msg3

    sq_invalid      db 10, "Invalid input!", 10
    sq_invalidLen   equ $ - sq_invalid

    sq_newline      db 10
    sq_space        db " "
    sq_symbol       db "*"

    ; ------------------------------------------------------------------
    ; Diamond Generator data
    ; (renamed: prompt->dia_prompt, newline->dia_newline,
    ;           spacech->dia_spacech, starch->dia_starch,
    ;           err_msg->dia_err_msg, input_buf->dia_input_buf)
    ; ------------------------------------------------------------------
    dia_prompt      db "Enter diamond size (1-20): "
    dia_prompt_len  equ $ - dia_prompt

    dia_newline     db 10
    dia_spacech     db " "
    dia_starch      db "*"

    dia_err_msg     db "Invalid input! Please enter 1-20.", 10
    dia_err_len     equ $ - dia_err_msg


; =====================================================================
; SECTION .BSS
; =====================================================================
section .bss

    ; Main menu input buffer
    menu_input          resb 4

    ; Triangle BSS
    ; (renamed: input_buffer->tri_input_buffer, height->tri_height,
    ;           row_count->tri_row_count, col_count->tri_col_count)
    tri_input_buffer    resb 4
    tri_height          resb 1
    tri_row_count       resb 1
    tri_col_count       resb 1

    ; Rectangle BSS
    ; (renamed: buf->rect_buf)
    rect_buf            resb 64

    ; Square BSS
    ; (renamed: sizeInput->sq_sizeInput, symbolInput->sq_symbolInput,
    ;           typeInput->sq_typeInput, size->sq_size)
    sq_sizeInput        resb 2
    sq_symbolInput      resb 2
    sq_typeInput        resb 2
    sq_size             resb 1

    ; Diamond BSS
    ; (renamed: input_buf->dia_input_buf)
    dia_input_buf       resb 16


; =====================================================================
; SECTION .TEXT
; =====================================================================
section .text
    global _start


; =====================================================================
; MAIN ENTRY POINT & MENU
; =====================================================================
_start:

main_menu:
    ; Print menu banner and options
    mov eax, 4
    mov ebx, 1
    mov ecx, menu_header
    mov edx, menu_header_len
    int 0x80

    ; Read menu choice (digit + newline = 2 bytes)
    mov eax, 3
    mov ebx, 0
    mov ecx, menu_input
    mov edx, 2
    int 0x80

    ; Dispatch on choice character
    mov al, [menu_input]

    cmp al, '1'
    je  menu_do_triangle

    cmp al, '2'
    je  menu_do_rectangle

    cmp al, '3'
    je  menu_do_square

    cmp al, '4'
    je  menu_do_diamond

    cmp al, '5'
    je  menu_do_exit

    ; Invalid menu choice — show error, loop back
    mov eax, 4
    mov ebx, 1
    mov ecx, menu_err
    mov edx, menu_err_len
    int 0x80

    jmp main_menu

menu_do_triangle:
    call triangle_program
    jmp  main_menu

menu_do_rectangle:
    call rectangle_program
    jmp  main_menu

menu_do_square:
    call square_program
    jmp  main_menu

menu_do_diamond:
    call diamond_program
    jmp  main_menu

menu_do_exit:
    mov eax, 1
    xor ebx, ebx
    int 0x80


; =====================================================================
; TRIANGLE PROGRAM  (original author's code preserved inside)
; Integration changes:
;   - _start -> triangle_program
;   - outer_loop -> tri_outer_loop
;   - inner_loop -> tri_inner_loop
;   - end_inner  -> tri_end_inner
;   - invalid_input -> tri_invalid_input
;   - exit_program  -> tri_exit_program  (sys_exit replaced with ret)
;   - tri_invalid_input now jumps to tri_exit_program instead of sys_exit
; =====================================================================
triangle_program:

    ; ==========================
    ; Print Prompt
    ; ==========================
    mov eax, 4              ; sys_write
    mov ebx, 1              ; stdout
    mov ecx, tri_prompt
    mov edx, tri_prompt_len
    int 0x80

    ; ==========================
    ; Read Input
    ; ==========================
    mov eax, 3              ; sys_read
    mov ebx, 0              ; stdin
    mov ecx, tri_input_buffer
    mov edx, 4
    int 0x80

    ; ==========================
    ; Validate Input
    ; ==========================
    mov al, [tri_input_buffer]

    ; Check range '1' to '9'
    cmp al, '1'
    jl  tri_invalid_input

    cmp al, '9'
    jg  tri_invalid_input

    ; Ensure second char is newline
    mov bl, [tri_input_buffer + 1]
    cmp bl, 10
    jne tri_invalid_input

    ; Convert ASCII to integer
    sub al, '0'
    mov [tri_height], al

    ; row_count = 1
    mov byte [tri_row_count], 1

; ==========================
; Outer Loop (Rows)
; ==========================
tri_outer_loop:

    mov al, [tri_row_count]
    cmp al, [tri_height]
    jg  tri_exit_program

    ; col_count = 1
    mov byte [tri_col_count], 1

; ==========================
; Inner Loop (Stars)
; ==========================
tri_inner_loop:

    mov al, [tri_col_count]
    cmp al, [tri_row_count]
    jg  tri_end_inner

    ; Print star
    push eax
    push ebx

    mov eax, 4              ; sys_write
    mov ebx, 1              ; stdout
    mov ecx, tri_star
    mov edx, 1
    int 0x80

    pop ebx
    pop eax

    ; Increment column counter
    inc byte [tri_col_count]
    jmp tri_inner_loop

; ==========================
; End of Row
; ==========================
tri_end_inner:

    ; Print newline
    push eax
    push ebx

    mov eax, 4
    mov ebx, 1
    mov ecx, tri_newline
    mov edx, 1
    int 0x80

    pop ebx
    pop eax

    ; Next row
    inc byte [tri_row_count]
    jmp tri_outer_loop

; ==========================
; Invalid Input
; ==========================
tri_invalid_input:

    mov eax, 4
    mov ebx, 1
    mov ecx, tri_err_msg
    mov edx, tri_err_len
    int 0x80

    ; Return to main menu (was: sys_exit with code 1)
    jmp tri_exit_program

; ==========================
; Exit (return to caller)
; ==========================
tri_exit_program:
    ret


; =====================================================================
; RECTANGLE PROGRAM  (original author's code preserved inside)
; Integration changes:
;   - _start          -> rectangle_program
;   - exit_program    -> rect_done  (replaced sys_exit with ret)
;   - bad_num         -> rect_bad_num  (jumps to rect_done)
;   - print_null      -> rect_print_null
;   - read_line       -> rect_read_line
;   - draw_star       -> rect_draw_star
;   - draw_space      -> rect_draw_space
;   - print_newline   -> rect_print_newline
;   - atoi            -> rect_atoi
;   - buf             -> rect_buf  (all references updated)
;   - All data/bss labels prefixed rect_
; =====================================================================
rectangle_program:

    ; ----- read & validate WIDTH (1-40) -> ebx -----
    mov   ecx, rect_prompt_width
    call  rect_print_null
    call  rect_read_line
    call  rect_atoi                    ; result in eax
    mov   ebx, eax                     ; width -> ebx
    cmp   ebx, 1
    jl    rect_bad_num
    cmp   ebx, 40
    jg    rect_bad_num

    ; ----- read & validate HEIGHT (1-20) -> esi -----
    mov   ecx, rect_prompt_height
    call  rect_print_null
    call  rect_read_line
    call  rect_atoi
    mov   esi, eax                     ; height -> esi
    cmp   esi, 1
    jl    rect_bad_num
    cmp   esi, 20
    jg    rect_bad_num

    ; ----- read FILL choice -----
    mov   ecx, rect_prompt_fill
    call  rect_print_null
    call  rect_read_line
    mov   al, [rect_buf]               ; first character of the response
    cmp   al, 'o'
    je    rect_outline
    jmp   rect_filled                  ; default to filled for anything else

; ---------------------------------------------------------------------
; rect_filled : prints a solid rectangle
;   esi = height (outer/row counter), ebx = width (inner/col counter)
; ---------------------------------------------------------------------
rect_filled:
    mov   edi, esi                     ; edi = remaining rows
.rf_row_loop:
    cmp   edi, 0
    jle   .rf_done
    push  edi                          ; save row counter across inner loop
    mov   ecx, ebx                     ; ecx = remaining columns
.rf_col_loop:
    cmp   ecx, 0
    jle   .rf_row_end
    call  rect_draw_star
    dec   ecx
    jmp   .rf_col_loop
.rf_row_end:
    call  rect_print_newline
    pop   edi
    dec   edi
    jmp   .rf_row_loop
.rf_done:
    jmp   rect_done

; ---------------------------------------------------------------------
; rect_outline : prints a hollow rectangle
;   First & last rows are solid; middle rows show only left/right walls.
;   esi = height, ebx = width
; ---------------------------------------------------------------------
rect_outline:
    mov   edi, esi                     ; edi = current row (counts down)
.ro_row_loop:
    cmp   edi, 0
    jle   .ro_done

    ; top row (edi == esi) or bottom row (edi == 1) -> full line
    cmp   edi, esi
    je    .ro_full_line
    cmp   edi, 1
    je    .ro_full_line

    ; ----- middle row: left wall, spaces, right wall -----
    call  rect_draw_star               ; left border
    push  edi
    mov   ecx, ebx
    sub   ecx, 2                       ; interior width = width - 2
.ro_space_loop:
    cmp   ecx, 0
    jle   .ro_space_done
    call  rect_draw_space
    dec   ecx
    jmp   .ro_space_loop
.ro_space_done:
    call  rect_draw_star               ; right border
    call  rect_print_newline
    pop   edi
    dec   edi
    jmp   .ro_row_loop

.ro_full_line:
    push  edi
    mov   ecx, ebx
.ro_full_loop:
    cmp   ecx, 0
    jle   .ro_full_done
    call  rect_draw_star
    dec   ecx
    jmp   .ro_full_loop
.ro_full_done:
    call  rect_print_newline
    pop   edi
    dec   edi
    jmp   .ro_row_loop
.ro_done:
    jmp   rect_done

; ---------------------------------------------------------------------
; Error handler for invalid numeric input
; ---------------------------------------------------------------------
rect_bad_num:
    mov   ecx, rect_invalid_num
    call  rect_print_null

; ---------------------------------------------------------------------
; rect_done : return to caller (was: sys_exit)
; ---------------------------------------------------------------------
rect_done:
    ret

; =====================================================================
; RECTANGLE UTILITY SUBROUTINES
; =====================================================================

; rect_print_null : write a null-terminated string in ecx to stdout
rect_print_null:
    push  ebx
    push  ecx
    push  edx
    mov   edx, 0                       ; length counter
    mov   eax, ecx
.pn_len:
    cmp   byte [eax], 0
    je    .pn_write
    inc   eax
    inc   edx
    jmp   .pn_len
.pn_write:
    mov   eax, 4                       ; sys_write
    mov   ebx, 1                       ; stdout
                                       ; ecx already = string addr
    int   0x80
    pop   edx
    pop   ecx
    pop   ebx
    ret

; rect_read_line : read up to 63 bytes from stdin into rect_buf
;   Clears the buffer first so leftover bytes never corrupt rect_atoi.
rect_read_line:
    push  eax
    push  ebx
    push  ecx
    push  edx
    mov   ecx, rect_buf                ; zero the buffer
    mov   edx, 64
.rl_clear:
    mov   byte [ecx], 0
    inc   ecx
    dec   edx
    jnz   .rl_clear
    mov   eax, 3                       ; sys_read
    mov   ebx, 0                       ; stdin
    mov   ecx, rect_buf
    mov   edx, 63
    int   0x80
    pop   edx
    pop   ecx
    pop   ebx
    pop   eax
    ret

; rect_draw_star : print a single '*'
rect_draw_star:
    push  eax
    push  ebx
    push  ecx
    push  edx
    mov   eax, 4
    mov   ebx, 1
    mov   ecx, rect_star
    mov   edx, 1
    int   0x80
    pop   edx
    pop   ecx
    pop   ebx
    pop   eax
    ret

; rect_draw_space : print a single ' '
rect_draw_space:
    push  eax
    push  ebx
    push  ecx
    push  edx
    mov   eax, 4
    mov   ebx, 1
    mov   ecx, rect_space
    mov   edx, 1
    int   0x80
    pop   edx
    pop   ecx
    pop   ebx
    pop   eax
    ret

; rect_print_newline : print a line break
rect_print_newline:
    push  eax
    push  ebx
    push  ecx
    push  edx
    mov   eax, 4
    mov   ebx, 1
    mov   ecx, rect_newline
    mov   edx, 1
    int   0x80
    pop   edx
    pop   ecx
    pop   ebx
    pop   eax
    ret

; rect_atoi : convert ASCII string in rect_buf to integer in eax
;   Stops at first non-digit. Returns 0 if first char is not a digit,
;   which is then caught by the range validation in rectangle_program.
rect_atoi:
    push  ebx
    push  ecx
    push  edx
    xor   eax, eax                     ; result = 0
    mov   ecx, rect_buf
.atoi_loop:
    movzx edx, byte [ecx]
    cmp   dl, '0'
    jl    .atoi_done                   ; below '0' -> not a digit
    cmp   dl, '9'
    jg    .atoi_done                   ; above '9' -> not a digit
    sub   dl, '0'                      ; ASCII -> numeric value
    imul  eax, eax, 10                 ; result *= 10
    add   eax, edx                     ; result += digit
    inc   ecx
    jmp   .atoi_loop
.atoi_done:
    pop   edx
    pop   ecx
    pop   ebx
    ret


; =====================================================================
; SQUARE PROGRAM  (original author's code preserved inside)
; Integration changes:
;   - _start          -> square_program
;   - star_symbol     -> sq_star_symbol
;   - hash_symbol     -> sq_hash_symbol
;   - at_symbol       -> sq_at_symbol
;   - square_type     -> sq_square_type
;   - filled_square   -> sq_filled_square
;   - filled_outer    -> sq_filled_outer
;   - filled_inner    -> sq_filled_inner
;   - hollow_square   -> sq_hollow_square
;   - hollow_outer    -> sq_hollow_outer
;   - hollow_inner    -> sq_hollow_inner
;   - print_symbol    -> sq_print_symbol
;   - continue_hollow -> sq_continue_hollow
;   - exit_program    -> sq_exit_program  (sys_exit replaced with ret)
;   - invalid_input   -> sq_invalid_input (sys_exit replaced with jmp sq_exit_program)
;   - All data/bss labels prefixed sq_
; =====================================================================
square_program:

  ;  ---------- SIZE INPUT------------

    mov eax, 4
    mov ebx, 1
    mov ecx, sq_msg1
    mov edx, sq_len1
    int 80h

    mov eax, 3
    mov ebx, 0
    mov ecx, sq_sizeInput
    mov edx, 2
    int 80h

    mov al, [sq_sizeInput]
    sub al, '0'

    cmp al, 1
    jl  sq_invalid_input

    cmp al, 9
    jg  sq_invalid_input

    mov [sq_size], al

  ;  ----------- SYMBOL MENU ----------

    mov eax, 4
    mov ebx, 1
    mov ecx, sq_msg2
    mov edx, sq_len2
    int 80h

    mov eax, 3
    mov ebx, 0
    mov ecx, sq_symbolInput
    mov edx, 2
    int 80h

    mov al, [sq_symbolInput]

    cmp al, '1'
    je  sq_star_symbol

    cmp al, '2'
    je  sq_hash_symbol

    cmp al, '3'
    je  sq_at_symbol

    jmp sq_invalid_input

sq_star_symbol:
    mov byte [sq_symbol], '*'
    jmp sq_square_type

sq_hash_symbol:
    mov byte [sq_symbol], '#'
    jmp sq_square_type

sq_at_symbol:
    mov byte [sq_symbol], '@'


sq_square_type:

  ; ---------- SQUARE TYPE MENU ------------

    mov eax, 4
    mov ebx, 1
    mov ecx, sq_msg3
    mov edx, sq_len3
    int 80h

    mov eax, 3
    mov ebx, 0
    mov ecx, sq_typeInput
    mov edx, 2
    int 80h

    mov al, [sq_typeInput]

    cmp al, '1'
    je  sq_filled_square

    cmp al, '2'
    je  sq_hollow_square

    jmp sq_invalid_input


sq_filled_square:

 ; ----------- FILLED SQUARE ---------------

    movzx ebp, byte [sq_size]

sq_filled_outer:

    movzx esi, byte [sq_size]

sq_filled_inner:

    mov eax, 4
    mov ebx, 1
    mov ecx, sq_symbol
    mov edx, 1
    int 80h

    dec esi
    jnz sq_filled_inner

    mov eax, 4
    mov ebx, 1
    mov ecx, sq_newline
    mov edx, 1
    int 80h

    dec ebp
    jnz sq_filled_outer

    jmp sq_exit_program


sq_hollow_square:

 ; ----------- HOLLOW SQUARE ----------------

    movzx ebp, byte [sq_size]
    mov edi, 0

sq_hollow_outer:

    movzx esi, byte [sq_size]
    mov edi, 0

sq_hollow_inner:

    ; first row
    cmp ebp, byte 1
    je  sq_print_symbol

    ; last row
    mov al, [sq_size]
    cmp ebp, eax
    je  sq_print_symbol

    ; first column
    cmp edi, 0
    je  sq_print_symbol

    ; last column
    mov al, [sq_size]
    dec al
    cmp edi, eax
    je  sq_print_symbol

    ; print space
    mov eax, 4
    mov ebx, 1
    mov ecx, sq_space
    mov edx, 1
    int 80h

    jmp sq_continue_hollow


sq_print_symbol:

    mov eax, 4
    mov ebx, 1
    mov ecx, sq_symbol
    mov edx, 1
    int 80h

sq_continue_hollow:

    inc edi
    dec esi
    jnz sq_hollow_inner

    mov eax, 4
    mov ebx, 1
    mov ecx, sq_newline
    mov edx, 1
    int 80h

    dec ebp
    jnz sq_hollow_outer

    ; fall through to sq_exit_program

 ; ---------- EXIT --------------

sq_exit_program:
    ret                                ; return to main menu (was: sys_exit)

 ; ----------- INVALID INPUT -------------

sq_invalid_input:

    mov eax, 4
    mov ebx, 1
    mov ecx, sq_invalid
    mov edx, sq_invalidLen
    int 80h

    ; Return to main menu (was: sys_exit with code 0)
    jmp sq_exit_program


; =====================================================================
; DIAMOND PROGRAM  (original author's code preserved inside)
; Integration changes:
;   - _start          -> diamond_program
;   - upper_loop      -> dia_upper_loop
;   - lower_start     -> dia_lower_start
;   - lower_loop      -> dia_lower_loop
;   - invalid_input   -> dia_invalid_input (sys_exit replaced with jmp dia_exit_ok)
;   - exit_ok         -> dia_exit_ok  (sys_exit replaced with ret)
;   - print_spaces    -> dia_print_spaces
;   - print_stars     -> dia_print_stars
;   - print_newline   -> dia_print_newline
;   - atoi            -> dia_atoi
;   - All data/bss labels prefixed dia_
; =====================================================================
diamond_program:

    ; print prompt
    mov eax, 4
    mov ebx, 1
    mov ecx, dia_prompt
    mov edx, dia_prompt_len
    int 0x80

    ; read input
    mov eax, 3
    mov ebx, 0
    mov ecx, dia_input_buf
    mov edx, 16
    int 0x80

    ; convert input (atoi)
    mov esi, dia_input_buf
    call dia_atoi

    ; validate
    cmp eax, -1
    je  dia_invalid_input
    cmp eax, 1
    jl  dia_invalid_input
    cmp eax, 20
    jg  dia_invalid_input

    mov edi, eax        ; N  (was r15)
    mov ebp, 1          ; i = 1  (was r12)

dia_upper_loop:
    cmp ebp, edi
    jg  dia_lower_start

    mov ecx, edi
    sub ecx, ebp
    call dia_print_spaces

    mov ecx, ebp
    imul ecx, 2
    dec ecx
    call dia_print_stars

    call dia_print_newline

    inc ebp
    jmp dia_upper_loop

dia_lower_start:
    mov ebp, edi
    dec ebp

dia_lower_loop:
    cmp ebp, 0
    jle dia_exit_ok

    mov ecx, edi
    sub ecx, ebp
    call dia_print_spaces

    mov ecx, ebp
    imul ecx, 2
    dec ecx
    call dia_print_stars

    call dia_print_newline

    dec ebp
    jmp dia_lower_loop

; ======================
; INVALID INPUT
; ======================
dia_invalid_input:
    mov eax, 4
    mov ebx, 1
    mov ecx, dia_err_msg
    mov edx, dia_err_len
    int 0x80

    ; Return to main menu (was: sys_exit with code 1)
    jmp dia_exit_ok

; ======================
; EXIT (return to caller)
; ======================
dia_exit_ok:
    ret                                ; return to main menu (was: sys_exit)

; ======================
; DIA_PRINT_SPACES
; ======================
dia_print_spaces:
    push ebx
    mov ebx, ecx

.ps:
    cmp ebx, 0
    jle .done

    mov eax, 4
    mov ecx, dia_spacech
    push ebx             ; preserve counter across syscall
    mov ebx, 1
    mov edx, 1
    int 0x80
    pop ebx

    dec ebx
    jmp .ps

.done:
    pop ebx
    ret

; ======================
; DIA_PRINT_STARS
; ======================
dia_print_stars:
    push ebx
    mov ebx, ecx

.pt:
    cmp ebx, 0
    jle .done

    mov eax, 4
    push ebx
    mov ebx, 1
    mov ecx, dia_starch
    mov edx, 1
    int 0x80
    pop ebx

    dec ebx
    jmp .pt

.done:
    pop ebx
    ret

; ======================
; DIA_PRINT_NEWLINE
; ======================
dia_print_newline:
    mov eax, 4
    mov ebx, 1
    mov ecx, dia_newline
    mov edx, 1
    int 0x80
    ret

; ======================
; DIA_ATOI (safe, pointer passed in esi)
; ======================
dia_atoi:
    xor eax, eax
    xor ecx, ecx

.loop:
    movzx edx, byte [esi]

    cmp edx, 10
    je .done
    cmp edx, 0
    je .done

    cmp edx, '0'
    jl .bad
    cmp edx, '9'
    jg .bad

    sub edx, '0'
    imul eax, 10
    add eax, edx

    inc esi
    inc ecx
    jmp .loop

.done:
    cmp ecx, 0
    je .bad
    ret

.bad:
    mov eax, -1
    ret
