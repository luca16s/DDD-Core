#!/usr/bin/env bash
curl -s https://codecov.io/bash > codecov
chmod +x codecov
./codecov -f "DomainCore_coverage.xml" -t CODECOV_TOKEN