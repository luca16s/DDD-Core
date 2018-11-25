#!/usr/bin/env bash
curl -s https://codecov.io/bash > codecov
chmod +x codecov
cd CodeCoverageResults
./codecov -f "coverage.opencover.xml" -t CODECOV_TOKEN