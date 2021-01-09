import { TableCell, TableRow } from '@material-ui/core'
import { Skeleton } from '@material-ui/lab'
import React from 'react'

export default ({ row }: { row: number }) => {
  const widths = [ 160, 90, 200 ]

  return (
    <TableRow>
      <TableCell>
        <Skeleton 
          animation="wave" 
          width={30} 
        />
      </TableCell>
      <TableCell>
        <Skeleton 
          animation="wave" 
          width={widths[row % widths.length]}
        />
      </TableCell>
      <TableCell align="right">
        <Skeleton 
          animation="wave" 
          width={80} 
        />
      </TableCell>
    </TableRow>
  )
}
