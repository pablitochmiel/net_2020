#!/bin/bash

for file in $(find . -name coverage.cobertura.xml)
do
  echo -n "Processing $file file... "

  if grep -q coverage "$file"; then
    if grep coverage $file | grep -q line-rate; then
     
      coverage=$(grep coverage $file | grep line-rate | cut -d'"' -f2)
 
      if (( $(awk 'BEGIN {print ("'$coverage'" < 1.0)}') )); then
        echo "[Incomplete coverage: $coverage]"
        exit 1
      fi
      
      echo "[OK]"
    
    else
      echo "[Missing coverage.line-rate attribute]"
      exit 1
    fi
  else
    echo "[Missing <coverage/> tag]"
    exit 1
  fi
done
