   function hex_dump(buf,first,last)
      local function align(n) return math.ceil(n/16) * 16 end
      for i=(align((first or 1)-16)+1),align(math.min(last or #buf,#buf)) do
         if (i-1) % 16 == 0 then io.write(string.format('%08X  ', i-1)) end
         io.write( i > #buf and '   ' or string.format('%02X ', buf:byte(i)) )
         if i %  8 == 0 then io.write(' ') end
         if i % 16 == 0 then io.write( buf:sub(i-16+1, i):gsub('%c','.'), '\n' ) end
         end
      end